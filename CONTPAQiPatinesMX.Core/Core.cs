using CONTPAQiPatinesMX.Core.Modelos;
using CONTPAQiPatinesMX.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTPAQiPatinesMX.Core
{
    public class Core
    {
        private static Core? _instance;
        private static readonly object _lock = new object();

        private SDKIntegration _sdkIntegration;
        public bool SesionSDKActiva { get; private set; } = false;

        private Core()
        {
            _sdkIntegration = SDKIntegration.Instance;
        #if DEBUG
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        #endif
        }

        public static Core Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Core();
                    return _instance;
                }
            }
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            // Si la sesión está activa, cerramos la sesión
            if (SesionSDKActiva)
            {
                TerminarSesion();
            }
        }

        ~Core()
        {
            // Cuando el objeto se destruye, aseguramos que la sesión se cierre
            if (SesionSDKActiva)
            {
                TerminarSesion(); // Llamar a TerminarSesion si la sesión está activa
            }
        }

        public bool IniciarSesion(string usuario, string contrasenia)
        {
            SesionSDKActiva = _sdkIntegration.InicioSesion(usuario, contrasenia);
            return SesionSDKActiva;
        }

        public void TerminarSesion()
        {
            SesionSDKActiva = false;
            _sdkIntegration.TerminaSDK();
        }

        public List<Empresa> ObtenerEmpresas()
        {
            var empresasRaw = _sdkIntegration.ObtenerEmpresas();
            List<Empresa> empresas = new List<Empresa>();

            foreach (var emp in empresasRaw)
            {
                empresas.Add(new Empresa
                {
                    Id = emp.Id,
                    Nombre = emp.Nombre,
                    Directorio = emp.Directorio
                });
            }

            return empresas;
        }

    }

}
