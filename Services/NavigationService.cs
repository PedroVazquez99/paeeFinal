using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TPVproyecto.Interfaces;

namespace TPVproyecto.Services
{
    public class NavigationService : INavigationService
    {
        // Variables
        private readonly Dictionary<string, Uri> _paginas = new Dictionary<string, Uri>();
        private Frame _frame;

        // CONTRUCTOR
        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        // Configuracion de las páginas. Es especifica el par clave-URI
        public void Configurar(string key, Uri pageUri)
        {
            if (!_paginas.ContainsKey(key))
                _paginas[key] = pageUri;
        }

        // Navegar a una pagina en concreto
        public void NavegarA(string pageKey)
        {
            if (_paginas.TryGetValue(pageKey, out Uri pageUri))
            {
                _frame.Navigate(pageUri);
            }
            else
            {
                throw new ArgumentException($"Página no encontrada {pageKey}");
            }
        }

        // Navrgar atras
        public void NavegarAtras()
        {
            if (_frame.CanGoBack)
                _frame.GoBack();
        }
    }
}
