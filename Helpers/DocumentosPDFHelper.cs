using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using TPVproyecto.Models.Pedido;

namespace TPVproyecto.Helpers
{
    public class DocumentosPDFHelper
    {
        public static void GenerarTicketPDF(Pedido pedido, string rutaDestino)
        {
            // Create document and section
            Document doc = new Document();
            Section section = doc.AddSection();

            // Configure ticket size
            section.PageSetup.PageWidth = Unit.FromCentimeter(8);
            section.PageSetup.PageHeight = Unit.FromCentimeter(20); // Adjust height as needed
            section.PageSetup.LeftMargin = Unit.FromCentimeter(0.5);
            section.PageSetup.RightMargin = Unit.FromCentimeter(0.5);
            section.PageSetup.TopMargin = Unit.FromCentimeter(0.5);
            section.PageSetup.BottomMargin = Unit.FromCentimeter(0.5);

            string fuente = "Verdana";

            // Header
            Paragraph encabezado = section.AddParagraph("CAFETERÍA AZUL", "Header");
            encabezado.Format.Font.Size = 12;
            encabezado.Format.Font.Bold = true;
            encabezado.Format.Alignment = ParagraphAlignment.Center;
            encabezado.Format.SpaceAfter = "0.3cm";

            // Order Info
            AddInfoLine(section, $"Pedido: #{pedido.ID_Pedido}", fuente);
            AddInfoLine(section, $"Mesa: {pedido.Mesa?.NombreMesa}", fuente);
            AddInfoLine(section, $"Fecha: {DateTime.Now:g}", fuente);
            AddDivider(section, fuente);

            // Order Details
            foreach (var linea in pedido.LineasPedido)
            {
                string texto = $"1 x {linea.Tipo?.NombreTipo} - {linea.Tamanyo?.NombreTamanyo}";

                if (!string.IsNullOrWhiteSpace(linea.Sabor?.SaborNombre))
                    texto += $" ({linea.Sabor.SaborNombre})";

                if (!string.IsNullOrWhiteSpace(linea.Topping?.ToppingNombre))
                    texto += $" + {linea.Topping.ToppingNombre}";

                AddInfoLine(section, texto, fuente);

                Paragraph pSubtotal = section.AddParagraph($"Subtotal: {linea.Subtotal:C2}", "Subtotal");
                pSubtotal.Format.Alignment = ParagraphAlignment.Right;
            }

            AddDivider(section, fuente);

            // Total
            Paragraph pTotal = section.AddParagraph($"TOTAL: {pedido.Total:C2}", "Total");
            pTotal.Format.Font.Size = 11;
            pTotal.Format.Font.Bold = true;
            pTotal.Format.Alignment = ParagraphAlignment.Right;

            // Render and save PDF
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true)
            {
                Document = doc,
                PdfDocument = new PdfDocument()
            };

            renderer.RenderDocument();
            renderer.PdfDocument.Save(rutaDestino);
        }

        private static void AddInfoLine(Section section, string text, string font)
        {
            Paragraph p = section.AddParagraph(text, "InfoLine");
            p.Format.Font.Name = font;
            p.Format.Font.Size = 10;
        }

        private static void AddDivider(Section section, string font)
        {
            Paragraph p = section.AddParagraph(new string('-', 32), "Divider");
            p.Format.Font.Name = font;
            p.Format.Font.Size = 10;
            p.Format.SpaceBefore = "0.2cm";
            p.Format.SpaceAfter = "0.2cm";
        }
    }
}
