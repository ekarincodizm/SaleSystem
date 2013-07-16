using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace SaleSystem.goods
{
    class pdf
    {
        public static void reportPdfSale(string s,string s2)
        {
            
            string location=  s2+".pdf";
            Document doc = new Document(iTextSharp.text.PageSize.A4, 50, 50, 30, 30);
            //PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("C:\\Test11.pdf", FileMode.Create));
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(@location, FileMode.Create));
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
            doc.Open();
            BaseFont angsa_normal = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\ANGSA.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            BaseFont angsa_bold = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\angsab.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            Font font = new Font(angsa_bold, 30);
            Font font_normal = new Font(angsa_normal, 16);
            Font font_bold = new Font(angsa_bold, 16);
            Paragraph paragraph = new Paragraph(s2 + '\n', font);
            Phrase detail_2 = new Phrase(s + '\n', font_normal);
            doc.Add(paragraph);
            doc.Add(detail_2);
            doc.Close();
            System.Diagnostics.Process.Start(@location);
        }
    }
}
