using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using TPVproyecto.Commands;
using TPVproyecto.Helpers;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.ViewModels.VentanasVM
{
    public class TicketWindowVM : BaseVM
    {
        public ICommand CargarPdfCommand { get; }
        private string _pdfFilePath;
        private BitmapImage _pdfImage;

        public string PdfFilePath
        {
            get => _pdfFilePath;
            set
            {
                _pdfFilePath = value;
                OnPropertyChanged(nameof(PdfFilePath));
            }
        }

        public BitmapImage PdfImage
        {
            get => _pdfImage;
            set
            {
                _pdfImage = value;
                OnPropertyChanged(nameof(PdfImage));
            }
        }

        private Pedido _pedido;

        public TicketWindowVM(Pedido pedido)
        {
            _pedido = pedido;
            CargarPdfCommand = new RelayCommand(ExecuteCargarPdf);
        }

        private void ExecuteCargarPdf(object parameter)
        {
            if (parameter is string filePath)
            {
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tickets");
                string rutaDestino = Path.Combine(folderPath, "ticket.pdf"); // Aquí se define el nombre del archivo
                PdfFilePath = rutaDestino;

                CargarPdf(rutaDestino);
            }
        }

        private void CargarPdf(string filePath)
        {
            DocumentosPDFHelper.GenerarTicketPDF(_pedido, PdfFilePath);


            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                MessageBox.Show("El archivo PDF no existe.");
                return;
            }

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Tickets");
            string rutaDestino = Path.Combine(folderPath, "ticket.pdf"); // Aquí se define el nombre del archivo

            // Guardar la ruta del archivo para mostrarla en la interfaz
            PdfFilePath = filePath;

            // Cargar el PDF y renderizarlo a imagen (esto es una simplificación)
            // RenderPdfToImage(rutaDestino);
        }

        private void RenderPdfToImage(string filePath)
        {
            try
            {
                // Aquí, creamos un documento PDF con MigraDoc (asumimos que ya tienes la generación del PDF)

                // Convertir PDF a Imagen
                // NOTA: PdfSharp no tiene la capacidad de convertir directamente PDF a imágenes.
                // Necesitas una librería como Pdfium para eso. Para este ejemplo, simplemente cargamos el PDF.

                // Crear un objeto PDF a partir de la ruta (es necesario un conversor para hacerlo visualizable en una imagen)
                // Aquí simplemente mostramos la ruta para propósitos de demostración.
                PdfDocument pdfDocument = PdfReader.Open(filePath, PdfDocumentOpenMode.ReadOnly);

                // Convertir la primera página del PDF en imagen (esto es solo un ejemplo, se necesitaría más para mostrarlo)
                var image = new BitmapImage(new Uri(filePath)); // Simulación de la imagen (esto necesita conversión real en un escenario real)

                PdfImage = image;

                MessageBox.Show($"El archivo PDF con {pdfDocument.PageCount} páginas ha sido cargado y convertido a imagen.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo PDF: {ex.Message}");
            }
        }
    }
}
