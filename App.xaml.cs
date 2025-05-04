using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using TPVproyecto.Helpers;
using TPVproyecto.Services;
using TPVproyecto.ViewModels;

namespace TPVproyecto
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    var frame = new Frame();
        //    var navigationService = new NavigationService(frame);

        //    navigationService.Configurar("Inicio", new Uri("MainWindow.xaml", UriKind.Relative));
        //    navigationService.Configurar("Admin", new Uri("Views/Paginas/AdminPage.xaml", UriKind.Relative));

        //    // Crea la ventana principal y asigna el Frame como contenido
        //    var mainWindow = new MainWindow();
        //    mainWindow.Content = frame;
        //    mainWindow.Show();

        //    // Inicia la navegación a la página principal
        //    navigationService.NavegarA("Admin");


        //}


        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();

            // Asignamos un CurrentViewModel, una vista a renderizar
            navigationStore.CurrentViewModel = new InicioVM(navigationStore);

            // Creamos la pantalla principal
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(navigationStore)

            };
            // La mostramos

            MainWindow.Show();

            base.OnStartup(e);

            Config config = Config.GetInstance();
            config.lang = "es";
            config.idMesaSeleccionada = -1;
        }

    }


}
