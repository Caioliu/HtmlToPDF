using System;
using System.IO;
using DinkToPdf;
using DinkToPdf.Contracts;

class Program {
    static void Main(string[] args) {
        var html = File.ReadAllText("Contrato.html");

        var globalSettings = new GlobalSettings {
            ColorMode = ColorMode.Color,
            Orientation = Orientation.Portrait,
            PaperSize = PaperKind.A4,
        };

        var objectSettings = new ObjectSettings {
            PagesCount = true,
            HtmlContent = html,
            WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "Contrato.css") },
        };

        var pdf = new HtmlToPdfDocument() {
            GlobalSettings = globalSettings,
            Objects = { objectSettings }
        };

        var converter = new SynchronizedConverter(new PdfTools());
        byte[] pdfData = converter.Convert(pdf);
        File.WriteAllBytes("arquivo41.pdf", pdfData);
    }

}
