using System.IO;
using System.Reflection;
using IronPdf;

namespace IronPdf_turn180degree_FormatBug
{
    internal class Program
    {
        private static void Main()
        {
            var filenamePattern = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory +
                                  @"\test_formula#rotation#.pdf";
            var rotated000 = filenamePattern.Replace("#rotation#", string.Empty);
            var rotated090 = filenamePattern.Replace("#rotation#", "_090");
            var rotated180 = filenamePattern.Replace("#rotation#", "_180");
            var rotated270 = filenamePattern.Replace("#rotation#", "_270");
            var rotated360 = filenamePattern.Replace("#rotation#", "_360");

            var pdf = new PdfDocument(rotated000);
            pdf.RotateAllPages(90); //90
            while (!pdf.Stream.CanWrite) continue;

            pdf.SaveAs(rotated090); //incorrect
            pdf.RotateAllPages(90); //180
            while (!pdf.Stream.CanWrite) continue;

            pdf.SaveAs(rotated180); //correct


            pdf.RotateAllPages(90); //270
            while (!pdf.Stream.CanWrite) continue;

            pdf.SaveAs(rotated270); //incorrect


            pdf.RotateAllPages(90); //360
            while (!pdf.Stream.CanWrite) continue;

            pdf.SaveAs(rotated360); //correct
        }
    }
}