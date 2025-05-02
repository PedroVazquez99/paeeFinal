using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using PdfSharp.Pdf;
using PdfSharp.Snippets.Font;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPVproyecto.Helpers
{
    public class DocumentosPDFHelper
    {

        //public bool SavePDF(List<Provincia> provincias, string path)
        //{
        //    try
        //    {
        //        if (PdfSharp.Capabilities.Build.IsCoreBuild)
        //            GlobalFontSettings.FontResolver = new FailsafeFontResolver();

        //        Document document = new Document(); // Se crea el Documento
        //        Section section = document.AddSection();
        //        Paragraph paragraph = section.AddParagraph();
        //        paragraph.AddText("Provincias"); // Encabezado
        //        paragraph.Format.Font.Size = 20;
        //        paragraph.Format.Font.Bold = true;
        //        paragraph.Format.Alignment = ParagraphAlignment.Center;

        //        section.AddParagraph();

        //        // Se agrega el formato tabla al documento
        //        Table table = section.AddTable();
        //        table.Style = "Table";

        //        // Columna ID
        //        Column column = table.AddColumn("2cm");
        //        column.Format.Alignment = ParagraphAlignment.Center;

        //        // Columna Provincia
        //        column = table.AddColumn("3cm");
        //        column.Format.Alignment = ParagraphAlignment.Left;

        //        // Columna Poblacion
        //        column = table.AddColumn("3cm");
        //        column.Format.Alignment = ParagraphAlignment.Left;

        //        // Columna Superficie
        //        column = table.AddColumn("3cm");
        //        column.Format.Alignment = ParagraphAlignment.Left;

        //        //  Columna Gentilicio
        //        column = table.AddColumn("3cm");
        //        column.Format.Alignment = ParagraphAlignment.Left;

        //        // Columna Escudo
        //        column = table.AddColumn("3cm");
        //        column.Format.Alignment = ParagraphAlignment.Left;

        //        Row row = table.AddRow();
        //        row.HeadingFormat = true;

        //        row.Format.Font.Bold = true;
        //        row.Shading.Color = Colors.LightBlue;
        //        row.Cells[0].AddParagraph("ID").Format.Alignment = ParagraphAlignment.Center;
        //        row.Cells[1].AddParagraph("Provincia");
        //        row.Cells[2].AddParagraph("Poblacion");
        //        row.Cells[3].AddParagraph("Superficie");
        //        row.Cells[4].AddParagraph("Gentilicio");
        //        row.Cells[5].AddParagraph("Escudo");

        //        int index = 0;

        //        string imageDomain = AppDomain.CurrentDomain.BaseDirectory;

        //        MigraDoc.DocumentObjectModel.Shapes.Image img = new MigraDoc.DocumentObjectModel.Shapes.Image();

        //        foreach (Provincia p in provincias)
        //        {
        //            if (index % 2 == 0 && index != 0)
        //            {
        //                row.Shading.Color = Colors.AntiqueWhite;
        //            }
        //            row = table.AddRow();
        //            row.Cells[0].AddParagraph(p.ID.ToString()).Format.Alignment = ParagraphAlignment.Center;
        //            row.Cells[1].AddParagraph(p.Nombre);
        //            row.Cells[2].AddParagraph(p.Poblacion);
        //            row.Cells[3].AddParagraph(p.Superficie);
        //            row.Cells[4].AddParagraph(p.Gentilicio);

        //            // Construye la ruta completa del archivo en la carpeta Assets del proyecto principal
        //            string assetPath = System.IO.Path.Combine(imageDomain, "assets", p.Src.ToString() + ".png");

        //            img = row.Cells[5].AddImage(assetPath);

        //            img.Width = Unit.FromCentimeter(1);  // Ajusta el ancho a 2 cm
        //            img.Height = Unit.FromCentimeter(1); // Ajusta el alto a 2 cm


        //            index++;
        //        }

        //        PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer
        //        {
        //            Document = document,
        //            PdfDocument = new PdfDocument()
        //        };
        //        pdfRenderer.RenderDocument();
        //        pdfRenderer.PdfDocument.Save(path);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

    }
}
