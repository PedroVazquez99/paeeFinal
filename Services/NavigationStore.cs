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
        private Stack<BaseVM> _navigationHistory = new Stack<BaseVM>(); // 🔄 Historial de navegación

        public BaseVM CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                if (_currentViewModel != null)
                {
                    _navigationHistory.Push(_currentViewModel); // 🔄 Guarda el actual antes de cambiar
                }

                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        // 🔙 Método para volver atrás
        public void NavigateBack()
        {
            if (_navigationHistory.Count > 0)
            {
                _currentViewModel = _navigationHistory.Pop(); // 🔄 Recupera el último ViewModel
                OnCurrentViewModelChanged();
            }
        }
    }
}
