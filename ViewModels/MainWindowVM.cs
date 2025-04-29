using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.Services;
using TPVproyecto.ViewModels.Admin;

namespace TPVproyecto.ViewModels
{
    
    public class MainWindowVM : BaseVM
    {
        private readonly NavigationStore _navigationStore;
        public BaseVM CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainWindowVM(NavigationStore navigationStore) {


            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
