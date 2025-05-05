using MigraDoc.DocumentObjectModel.Internals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models;
using TPVproyecto.Services;

namespace TPVproyecto.ViewModels.VentanasVM
{
    public class MesaVentanaVM : BaseVM
    {
        
        // Servicios
        private MesaService _mesaService;
        private HeladoService _heladoService;
        public Action CerrarVentana { get; set; }
        // Variables
        private ObservableCollection<Mesa> _mesas;
        public ObservableCollection<Mesa> Mesas {
            get {  return _mesas; }
            set {
                _mesas = value;
                OnPropertyChanged(nameof(Mesa));
            } 
        }
        private Mesa _mesaSeleccionada;
        public Mesa MesaSeleccionada
        {
            get { return _mesaSeleccionada; }
            set
            {
                _mesaSeleccionada = value;
                OnPropertyChanged(nameof(MesaSeleccionada));
                
            }
        }

        private ObservableCollection<Helado> _heladosList;

        //Comandos
        public ICommand MiComando { get; }
        public ICommand AceptarCommand { get; }

        // Variables Globales
        Config config;

        // CONSTRUCTOR
        public MesaVentanaVM(ObservableCollection<Helado> heladosList) {

            config = Config.GetInstance();

            _mesaService = new MesaService();
            _heladoService = new HeladoService();
            _heladosList = heladosList;

            _mesas = _mesaService.obtenerMesas();
            
            MiComando = new RelayCommand(
                execute: EjecutarComando,
                canExecute: PuedeEjecutarComando
            );

            AceptarCommand = new RelayCommand(
                execute: EjecutarAceptar,
                canExecute: PuedeEjecutarAceptar
            );

        }

        // Funciones Mesas
        private void EjecutarComando(object parameter)
        {
            _mesaSeleccionada = (Mesa)parameter;
            config.idMesaSeleccionada = MesaSeleccionada.Id;
            Console.WriteLine(_mesaSeleccionada);
        }

        private bool PuedeEjecutarComando(object parameter)
        {
            return true;
        }

        // Funciones Aceptar
        private void EjecutarAceptar(object parameter)
        {
            Console.Write(parameter);
            if(_heladosList != null && _heladosList.Count > 0 && MesaSeleccionada != null && MesaSeleccionada.IsActivo == false)
            {
                try
                {
                    bool isMesaActivo = true;
                    _heladoService.guardarHelado(_heladosList, MesaSeleccionada);
                    if(MesaSeleccionada.Id > 1)
                    {
                        _mesaService.cambiarEstadoMesa(MesaSeleccionada.Id, isMesaActivo); // No se ccambia el estado de la mesa LLEVAR, es decir, siempre esta activada
                    }
                    config.idMesaSeleccionada = MesaSeleccionada.Id;

                    _heladosList.Clear();



                }
                catch (Exception ex) {
                    MessageBox.Show("No se pudo guardar la cuenta correctamente");
                }
            }
            else
            {
                _heladosList.Clear();
                ObservableCollection<Helado> heladosLista = _heladoService.ObtenerHeladosNoPagados(MesaSeleccionada.Id);
                foreach (Helado helado in heladosLista) // Suponiendo que heladosCollection es tu ObservableCollection original
                {
                    _heladosList.Add(helado);
                }
            }

            // Invocar la acción para cerrar la ventana
            CerrarVentana?.Invoke();
        }
        private bool PuedeEjecutarAceptar(object parameter)
        {
            /*return MesaSeleccionada != null; // si se cumple, se ejecuta*/
            return true;
        }

    }
}
