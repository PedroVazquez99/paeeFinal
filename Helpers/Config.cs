using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Helpers
{
    public class Config
    {
        private static Config _instance;

        public int idMesaSeleccionada { get; set; }
        public string lang { get; set; } // Para la i18n
        

        private Config() { }

        public static Config GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Config();
            }
            return _instance;
        }

    }

}
