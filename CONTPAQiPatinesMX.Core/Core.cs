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

        private Core()
        {
            _sdkIntegration = SDKIntegration.Instance;
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

        public bool IniciarSesion(string usuario, string contrasenia)
        {
            return _sdkIntegration.InicioSesion(usuario, contrasenia);
        }

        public void TerminarSesion()
        {
            _sdkIntegration.TerminaSDK();
        }
    }

}
