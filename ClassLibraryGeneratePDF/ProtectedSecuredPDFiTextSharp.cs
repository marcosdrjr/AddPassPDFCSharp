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
        public string GenerateOwnerPassword()
        {
            string WorkingFolder = "PDFs";
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");

            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    string password = "secret";
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                    byte[] bytes = output.ToArray();
                    //... convert file
                    var FileBase64 = Convert.ToBase64String(bytes);
                    return FileBase64;
                }
            }
        }
        public MemoryStream GenerateOwnerPasswordMemoryStream()
        {
            string WorkingFolder = "PDFs";
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");

            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream output = new MemoryStream())
                {   
                    string password = "secret";
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                    byte[] bytes = output.ToArray();
                    //... convert file
                    var FileBase64 = Convert.ToBase64String(bytes);
                    return output;
                }
            }
        }
        public byte[] GenerateOwnerPasswordByte()
        {
            string WorkingFolder = "PDFs";
            string InputFile = Path.Combine(WorkingFolder, "Test.pdf");

            using (Stream input = new FileStream(InputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MemoryStream output = new MemoryStream())
                {
                    string password = "secret";
                    PdfReader reader = new PdfReader(input);
                    PdfEncryptor.Encrypt(reader, output, true, password, password, PdfWriter.ALLOW_SCREENREADERS);
                    byte[] bytes = output.ToArray();
                    //... convert file
                    var FileBase64 = Convert.ToBase64String(bytes);
                    return bytes;
                }
            }
        }
    }
}