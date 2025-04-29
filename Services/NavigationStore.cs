using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPVproyecto.ViewModels;

namespace TPVproyecto.Services
{
    public class NavigationStore : BaseVM
    {
        public event Action CurrentViewModelChanged;

        private BaseVM _currentViewModel;

        public BaseVM CurrentViewModel { 
            get => _currentViewModel; 
            set 
            { 
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

    }
}
