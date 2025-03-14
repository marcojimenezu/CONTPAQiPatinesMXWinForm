using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTPAQiPatinesMX.Interop
{
    public interface IDLLIntegration
    {
        public string ObtenerRutaDll();
        bool InicializaSDK();
        void TerminaSDK();
        bool SetNombrePAQ(string nombrePAQ);
        bool InicioSesion(string usuario, string contrasenia);
        int ObtenerExistencia(string codigoProducto, string codigoAlmacen, DateTime fecha, out double existencia);
    }
}
