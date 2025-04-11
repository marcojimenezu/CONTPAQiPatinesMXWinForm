using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CONTPAQiPatinesMX.Interop
{
    public class Interfaces
    {
        //Funciones---------------------------------------------------------------------------------
        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int RegOpenKeyEx(
        UIntPtr hKey,
        string subKey,
        int ulOptions,
        int samDesired,
        out UIntPtr hkResult);

        // Funciones de Windows
        [DllImport("advapi32")]
        public static extern int RegCloseKey(UIntPtr hKey);

        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegQueryValueExW", SetLastError = true)]
        public static extern int RegQueryValueEx(
        UIntPtr hKey,
        string lpValueName,
        int lpReserved,
        out uint lpType,
        StringBuilder lpData,
        ref uint lpcbData);

        [DllImport("KERNEL32")]
        public static extern int SetCurrentDirectory(string pPtrDirActual);

        // Constantes SDK Premium
        public class Constantes
        {
            public const int kLongFecha = 24;
            public const int kLongSerie = 12;
            public const int kLongCodigo = 31;
            public const int kLongNombre = 61;
            public const int kLongReferencia = 21;
            public const int kLongDescripcion = 61;
            public const int kLongCuenta = 101;
            public const int kLongMensaje = 256;
            public const int kLongNombreProducto = 256;
            public const int kLongAbreviatura = 4;
            public const int kLongCodValorClasif = 4;
            public const int kLongDenComercial = 51;
            public const int kLongRepLegal = 51;
            public const int kLongTextoExtra = 51;
            public const int kLongRFC = 21;
            public const int kLongCURP = 21;
            public const int kLongDesCorta = 21;
            public const int kLongNumeroExtInt = 7;
            public const int kLongCodigoPostal = 7;
            public const int kLongTelefono = 16;
            public const int kLongEmailWeb = 51;
            public const int kLongitudNomBanExtranjero = 255;
        }

        // Estructuras SDK Premium
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDocumento
        {
            public double aFolio;
            public int aNumMoneda;
            public double aTipoCambio;
            public double aImporte;
            public double aDescuentoDoc1;
            public double aDescuentoDoc2;
            public int aSistemaOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string? aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongSerie)]
            public string? aSerie;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongFecha)]
            public string? aFecha;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string? aCodigoCteProv;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string? aCodigoAgente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongReferencia)]
            public string? aReferencia;
            public int aAfecta;
            public double aGasto1;
            public double aGasto2;
            public double aGasto3;
            public tDocumento()
            {
                aFolio = 0;
                aNumMoneda = 0;
                aTipoCambio = 0;
                aImporte = 0;
                aDescuentoDoc1 = 0;
                aDescuentoDoc2 = 0;
                aSistemaOrigen = 0;
                aCodConcepto = string.Empty;
                aSerie = string.Empty;
                aFecha = string.Empty;
                aCodigoCteProv = string.Empty;
                aCodigoAgente = string.Empty;
                aReferencia = string.Empty;
                aAfecta = 0;
                aGasto1 = 0;
                aGasto2 = 0;
                aGasto3 = 0;
            }
            public bool IsEmpty()
            {
                // Reemplaza esto con una verificación real de si el struct está "vacío"
                return this.Equals(default(tDocumento));
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tMovimiento
        {
            public int aConsecutivo;
            public double aUnidades;
            public double aPrecio;
            public double aCosto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string aCodProdSer;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string aCodAlmacen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongReferencia)]
            public string aReferencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = Interfaces.Constantes.kLongCodigo)]
            public string aCodClasificacion;
            public bool IsEmpty()
            {
                // Reemplaza esto con una verificación real de si el struct está "vacío"
                return this.Equals(default(tMovimiento));
            }
            public tMovimiento()
            {
                aConsecutivo = 0;
                aUnidades = 0;
                aPrecio = 0;
                aCosto = 0;
                aCodProdSer = string.Empty;
                aCodAlmacen = string.Empty;
                aReferencia = string.Empty;
                aCodClasificacion = string.Empty;
            }
        }

        // Funciones SDK Premium

        [DllImport("MGW000.dll")]
        public static extern int fSetNombrePAQ(StringBuilder aNombrePAQ);

        [DllImport("MGW000.dll")]
        public static extern void fInicioSesionSDK(StringBuilder aUsuario, StringBuilder aContrasenia);

        [DllImport("MGW000.dll")]
        public static extern int fInicializaSDK();

        [DllImport("MGW000.dll")]
        public static extern void fTerminaSDK();

        [DllImport("MGW000.dll")]
        public static extern int fPosPrimerEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGW000.dll")]
        public static extern int fPosSiguienteEmpresa(ref int aIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGW000.dll")]
        public static extern int fAbreEmpresa(StringBuilder Directorio);

        [DllImport("MGW000.dll")]
        public static extern void fCierraEmpresa();

        [DllImport("MGW000.dll")]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        [DllImport("MGW000.dll")]
        public static extern Int32 fInicializaLicenseInfo(int aSistema);

        [DllImport("MGW000.dll")]
        public static extern Int32 fAltaDocumento(ref Int32 aIdDocumento, ref tDocumento atDocumento);

        [DllImport("MGW000.dll")]
        public static extern Int32 fAltaMovimiento(Int32 aIdDocumento, ref Int32 aIdMovimiento, ref tMovimiento astMovimiento);

        [DllImport("MGW000.dll")]
        public static extern Int32 fSiguienteFolio(StringBuilder aCodigoConcepto, StringBuilder aSerie, ref double aFolio);

        [DllImport("MGW000.dll")]
        public static extern Int32 fInsertaDatoAddendaMovto(int aIdAddenda, int aIdCatalogo, int aNumCampo, StringBuilder aDato);

        [DllImport("MGW000.dll")]
        public static extern Int32 fDesbloqueaDocumento();

        [DllImport("MGW000.dll")]
        public static extern Int32 fEmitirDocumento(StringBuilder aCodConcepto, StringBuilder aSerie, double aFolio, StringBuilder aPassword, StringBuilder aArchivoAdicional);

        [DllImport("MGW000.dll")]
        public static extern Int32 fEntregEnDiscoXML(StringBuilder aCodConcepto, StringBuilder aSerie, double aFolio, int aFormato, StringBuilder aFormatoAmig);

        [DllImport("MGW000.dll")]
        public static extern Int32 fRegresaExistencia(
            StringBuilder aCodigoProducto,
            StringBuilder aCodigoAlmacen,
            StringBuilder aAnio,
            StringBuilder aMes,
            StringBuilder aDia,
            ref double aExistencia);

    }
}
