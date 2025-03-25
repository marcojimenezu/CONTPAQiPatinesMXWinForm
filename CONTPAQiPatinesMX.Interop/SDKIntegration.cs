using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTPAQiPatinesMX.Interop
{
    public class SDKIntegration : IDLLIntegration
    {
        private static SDKIntegration? _instance;
        private static readonly object _lock = new object();

        private SDKIntegration()
        {
            bool sdkInicializado;
            try
            {
                ObtenerRutaDll();
                //sdkInicializado = InicializaSDK();
                sdkInicializado = SetNombrePAQ("CONTPAQ I COMERCIAL");

                if (!sdkInicializado)
                    throw new Exception("No se pudo inicializar el SDK de CONTPAQi.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inicializar Interop: " + ex.Message);
            }
        }

        public static SDKIntegration Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new SDKIntegration();
                    return _instance;
                }
            }
        }

        public string ObtenerRutaDll()
        {
            UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
            long lResult;
            UIntPtr hRegKey;
            StringBuilder lEntrada = new StringBuilder(1024);
            uint pvSize = 1024;
            uint pdwType = 0;

            string szRegKeySistema = "SOFTWARE\\WOW6432Node\\Computación en Acción, SA CV\\CONTPAQ I COMERCIAL";

            // Abre la clave del registro
            lResult = Interfaces.RegOpenKeyEx(HKEY_LOCAL_MACHINE, szRegKeySistema, 0, 1, out hRegKey);
            if (lResult != 0)
            {
                // Si falla, lanzar una excepción
                throw new InvalidOperationException("Error al abrir el Registry");
            }

            // Lee la ruta desde el registro
            lResult = Interfaces.RegQueryValueEx(hRegKey, "DirectorioBase", 0, out pdwType, lEntrada, ref pvSize);
            if (lResult != 0)
            {
                // Si falla, cerrar la clave del registro y lanzar una excepción
                Interfaces.RegCloseKey(hRegKey);
                throw new InvalidOperationException("Error al leer la ruta desde el Registry");
            }

            Interfaces.RegCloseKey(hRegKey);

            // Verifica si la ruta existe
            string ruta = lEntrada.ToString();
            if (!Directory.Exists(ruta))
            {
                throw new DirectoryNotFoundException($"La ruta '{ruta}' no existe.");
            }
            else
            {
                Environment.CurrentDirectory = ruta;
            }

            return ruta;
        }

        public bool InicializaSDK()
        {
            int resultado = Interfaces.fInicializaSDK();
            return resultado == 0; // Asumimos que 0 indica éxito
        }

        public void TerminaSDK()
        {
            Interfaces.fTerminaSDK();
        }

        public bool SetNombrePAQ(string nombrePAQ)
        {
            StringBuilder sbNombrePAQ = new StringBuilder(nombrePAQ);
            int resultado = Interfaces.fSetNombrePAQ(sbNombrePAQ);
            return resultado == 0; // Asumimos que 0 indica éxito
        }

        public bool InicioSesion(string usuario, string contrasenia)
        {
            StringBuilder sbUsuario = new StringBuilder(usuario);
            StringBuilder sbContrasenia = new StringBuilder(contrasenia);
            try
            {
                StringBuilder sistema = new StringBuilder("CONTPAQ I COMERCIAL");
                int lError = 0;
                Interfaces.fInicioSesionSDK(sbUsuario, sbContrasenia);
                lError = Interfaces.fInicializaSDK();
                return true; // Si no hay excepciones, asumimos que es exitoso
            }
            catch
            {
                return false; // Manejo de excepciones simple
            }
        }

        public int ObtenerExistencia(string codigoProducto, string codigoAlmacen, DateTime fecha, out double existencia)
        {
            var codigoProductoSb = new StringBuilder(codigoProducto, 20);
            var codigoAlmacenSb = new StringBuilder(codigoAlmacen, 20);
            var anio = new StringBuilder(fecha.Year.ToString("0000"));
            var mes = new StringBuilder(fecha.Month.ToString("00"));
            var dia = new StringBuilder(fecha.Day.ToString("00"));

            double existenciaTemp = 0;

            int resultado = Interfaces.fRegresaExistencia(codigoProductoSb, codigoAlmacenSb, anio, mes, dia, ref existenciaTemp);
            existencia = existenciaTemp;

            return resultado; // Retorna el código de éxito/error.
        }
    }
}
