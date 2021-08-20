using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAddPassPDF
{
    public class ProtectedSecuredPDFiTextSharp
    {
        //https://www.aspsnippets.com/Articles/Create-Password-Protected-Secured-PDF-using-iTextSharp-in-ASPNet.aspx        
        //Apenas passe null para o userPassworde as pessoas poderão abri-lo sem especificar uma senha,
        //mas não poderão copiar o texto do pdf.
        public void GenerateUserPassword()
        {
            string WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\PDFs";
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");
            string OutputFile = Path.Combine(WorkingFolder, "Test_encUserPassword.pdf");

            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, null, "secret", PdfWriter.ALLOW_SCREENREADERS);
                }
            }
        }
        public void GenerateOwnerPassword()
        {
            string WorkingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\PDFs";
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");
            string OutputFile = Path.Combine(WorkingFolder, "Test_encOwnerPassword.pdf");

            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Stream output = new FileStream(OutputFile, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, "secret", "secret", PdfWriter.ALLOW_SCREENREADERS);
                }
            }
        }
    }
}
