using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Interfaces
{
    public interface INavigationService
    {
        void NavegarA(string pageKey);
        void NavegarAtras();
    }
}
