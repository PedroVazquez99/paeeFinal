using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TPVproyecto.ViewModels;
using TPVproyecto.Services;

namespace TPVproyecto.Views.Elegir
{
    /// <summary>
    /// Lógica de interacción para UCElegir.xaml
    /// </summary>
    public partial class ElegirUC : UserControl
    {
        //private ElegirVM _elegirVM;
        
        public ElegirUC()
        {
            InitializeComponent();

            //_elegirVM = new ElegirVM();
            //this.DataContext = _elegirVM; // asociamos vista con su ViewModel

        }
    }
}
