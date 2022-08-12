using DbAPI.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace DbAPI.Controllers
{

    public class InvoiceGenerator : ControllerBase
    {





        public async void CreateInvoices()
        {
            var timer = new PeriodicTimer(TimeSpan.FromSeconds(600));
            var client = new RestClient();



            while (await timer.WaitForNextTickAsync())
            {
                var request = new RestRequest("http://localhost:5223/api/Customers", Method.Get);
                List<Customers> CustomerList = JsonConvert.DeserializeObject<List<Customers>>(client.Execute(request).Content);

                foreach (Customers customer in CustomerList)
                {
                    request = new RestRequest("http://localhost:5223/api/Transactions", Method.Get);
                    List<Transactions> customerTransactions = JsonConvert.DeserializeObject<List<Transactions>>(client.Execute(request).Content).FindAll(c => c.Customer_Id == customer.Id);
                    GenerateInvoice(customerTransactions, customer.Id);
                }
            }




        }

        private void GenerateInvoice(List<Transactions> transactions, Guid customerId)
        {
            #region Common Part
            PdfPTable pdfTableBlank = new PdfPTable(1);

            //Footer Section
            PdfPTable pdfTableFooter = new PdfPTable(1);
            pdfTableFooter.DefaultCell.BorderWidth = 0;
            pdfTableFooter.WidthPercentage = 100;
            pdfTableFooter.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            Chunk cnkFooter = new Chunk("", FontFactory.GetFont("Times New Roman"));
            //cnkFooter.Font.SetStyle(1);
            cnkFooter.Font.Size = 10;
            pdfTableFooter.AddCell(new Phrase(cnkFooter));
            //End Of Footer Section

            pdfTableBlank.AddCell(new Phrase(" "));
            pdfTableBlank.DefaultCell.Border = 0;
            #endregion

            #region Page
            #region Section-1

            PdfPTable pdfTable1 = new PdfPTable(1);//Here 1 is Used For Count of Column

            PdfPTable pdfTable3 = new PdfPTable(5);

            //Font Style
            System.Drawing.Font fontH1 = new System.Drawing.Font("Currier", 16);

            //pdfTable1.DefaultCell.Padding = 5;
            pdfTable1.WidthPercentage = 80;
            pdfTable1.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable1.DefaultCell.VerticalAlignment = Element.ALIGN_CENTER;
            //pdfTable1.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(64, 134, 170);
            pdfTable1.DefaultCell.BorderWidth = 0;




            pdfTable3.DefaultCell.Padding = 5;
            pdfTable3.WidthPercentage = 95;
            pdfTable3.DefaultCell.BorderWidth = 0.5f;


            Chunk c1 = new Chunk("Faktura Vat", FontFactory.GetFont("Times New Roman"));
            c1.Font.Color = new iTextSharp.text.BaseColor(0, 0, 0);
            c1.Font.SetStyle(0);
            c1.Font.Size = 14;
            Phrase p1 = new Phrase();
            p1.Add(c1);
            pdfTable1.AddCell(p1);

            #endregion
            #region Section-1

            #endregion

            #region section Table

            foreach (Transactions tr in transactions)
            {
                pdfTable3.AddCell(new Phrase($"[{tr.Reference_Number}]"));
                pdfTable3.AddCell(new Phrase($"{tr.Description}"));
                pdfTable3.AddCell(new Phrase($"{tr.Date}"));
                pdfTable3.AddCell(new Phrase($"{tr.Price}"));
                pdfTable3.AddCell(new Phrase($"{tr.Customer_Id}"));
            }


            #endregion

            #endregion


            #region Pdf Generation


            string invNo = $"{customerId}-{DateTime.Now.Month}-{DateTime.Now.Year}";
            string strFileName = $"{invNo}.pdf";
            Decimal price = transactions.Sum(tr => tr.Price);


            if (!Directory.Exists("Data/Invoices"))
                Directory.CreateDirectory("Data/Invoices");

            string FilePath = Path.Combine($"Data/Invoices/", strFileName);



            using (FileStream stream = new FileStream(FilePath, FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                #region PAGE-1
                pdfDoc.Add(pdfTable1);

                pdfDoc.Add(pdfTableBlank);

                pdfDoc.Add(pdfTable3);
                pdfDoc.Add(pdfTableFooter);
                pdfDoc.NewPage();
                #endregion

                // pdfDoc.Add(jpg);

                //pdfDoc.Add(pdfTable2);
                pdfDoc.Close();
                stream.Close();
            }
            #endregion

            var client = new RestClient();
            var request = new RestRequest("http://localhost:5223/api/Invoices/", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", new Invoices { Id = 0, Currency_Id = 1, Customer_Id = customerId, Date = DateTime.Now, Document_Path = FilePath, Price = price, InvoiceNo = invNo }, ParameterType.RequestBody);
            var response = client.Execute(request);


        }

    }
}
