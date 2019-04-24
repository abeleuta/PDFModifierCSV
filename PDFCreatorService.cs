using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Text;

namespace PDFModifierCSV {
    internal class PDFCreatorService {

        public void ProcessCSVData(CSVData csvData) {

            Logger.Instance.Log("Processing file:" + csvData.FileName);
            foreach (InputRow row in csvData.InputRows) {
                Logger.Instance.Log("Creating PDF file:" + row.PdfOut);
                try {
                    CreatePDF(csvData, row);
                } catch (Exception ex) {
                    Logger.Instance.Log("Failed to create PDF file.");
                }
            }

        }

        private void CreatePDF(CSVData csvData, InputRow row) {
            PdfImageExporter pdfImageExporter = new PdfImageExporter();

            Document doc = new Document();
            FileStream stream = new FileStream(row.PdfOut, FileMode.Create);
            PdfWriter writter = PdfWriter.GetInstance(doc, stream);
            doc.Open();

            bool atLeastOnePageCreated = false;
            int pageNo = 0;
            foreach (string pdfFile in row.InputPDFs) {
                try {
                    using (PdfReader reader = new PdfReader(pdfFile)) {
                        int numPages = reader.NumberOfPages;

                        for (int i = 0; i < numPages; i++) {
                            var image = pdfImageExporter.ExtractImageFromPDF(pdfFile, reader, i);
                            doc.NewPage();

                            AddHeaderAndFooter(csvData, row, doc, image);

                            atLeastOnePageCreated = true;
                            pageNo++;
                        }
                    }
                } catch (FileNotFoundException) {
                    Logger.Instance.Log("Image not found:" + pdfFile);
                } catch (Exception ex) {
                    Logger.Instance.Log("Failed to add image to PDF. Image path:" + pdfFile);
                }
            }

            doc.Close();
            if (atLeastOnePageCreated) {
                if (!String.IsNullOrEmpty(row.XmlFile)) {
                    CreateXmlFile(row);
                }
                Logger.Instance.Log("PDF successfully created.");
            } else {
                Logger.Instance.Log("PDF not created as no image found.");
            }
            writter.Close();
            stream.Close();
        }

        private void CreateXmlFile(InputRow row) {
            StringBuilder sb = new StringBuilder();
            //<mdas><entity>Lot_Certificate</entity><acl>Public</acl><attrs>
            //<Item_Number>10030831</Item_Number><Lot_Number>83041926</Lot_Number>
            //<Cert_Type>Lot Cert</Cert_Type></attrs></mdas>
            sb.Append("<mdas><entity>Lot_Certificate</entity><acl>Public</acl><attrs><Item_Number>").
                Append(row.ItemNumber).Append("</Item_Number><Lot_Number>").
                Append(row.LotNumber).Append("</Lot_Number><Cert_Type>").
                Append(row.CertType).Append("</Cert_Type></attrs></mdas>");
            File.WriteAllText(row.XmlFile, sb.ToString());
        }

        private static void AddEmptyCell(PdfPTable table) {
            PdfPCell emptyCell = new PdfPCell();
            emptyCell.Border = 0;
            table.AddCell(emptyCell);
        }

        private void AddTextCell(PdfPTable table, string text, Font font, int alignment = PdfPCell.ALIGN_MIDDLE) {
            PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(text, font));
            cell.HorizontalAlignment = alignment;
            cell.Border = 0;
            table.AddCell(cell);
        }

        private void AddHeaderAndFooter(CSVData csvData, InputRow row, Document doc, System.Drawing.Image image) {
            string headerFooterString = row.HeaderFooterMetadata;

            var pageSize = doc.PageSize;
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            var fontRegular = FontFactory.GetFont("Arial", 7);

            if (csvData.HeaderLeft) {
                AddTextCell(table, headerFooterString, fontRegular, PdfPCell.ALIGN_LEFT);
            } else {
                AddEmptyCell(table);
            }

            if (csvData.HeaderCenter) {
                AddTextCell(table, headerFooterString, fontRegular);
            } else {
                AddEmptyCell(table);
            }

            if (csvData.HeaderRight) {
                AddTextCell(table, headerFooterString, fontRegular, PdfPCell.ALIGN_RIGHT);
            } else {
                AddEmptyCell(table);
            }

            doc.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            PdfPCell rightCell = new PdfPCell(new iTextSharp.text.Phrase("CERTIFIED TRUE COPY of Document held by Wencor QA", fontRegular));
            rightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            rightCell.Border = 0;
            table.AddCell(rightCell);
            doc.Add(table);

            table = new PdfPTable(1);
            table.DefaultCell.Border = 0;
            table.WidthPercentage = 100;

            var imageCell = Image.GetInstance(image, (BaseColor)null);
            //imageCell.SpacingAfter = 50;
            table.AddCell(imageCell);
            table.SpacingAfter = 20;
            table.SpacingBefore = 20;
            doc.Add(table);

            table = new PdfPTable(1);
            table.WidthPercentage = 100;
            rightCell = new PdfPCell(new iTextSharp.text.Phrase("CERTIFIED TRUE COPY of Document held by Wencor QA", fontRegular));
            rightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
            rightCell.Border = 0;
            table.AddCell(rightCell);
            doc.Add(table);

            table = new PdfPTable(3);
            table.WidthPercentage = 100;

            if (csvData.FooterLeft) {
                AddTextCell(table, headerFooterString, fontRegular, PdfPCell.ALIGN_LEFT);
            } else {
                AddEmptyCell(table);
            }

            if (csvData.FooterCenter) {
                AddTextCell(table, headerFooterString, fontRegular);
            } else {
                AddEmptyCell(table);
            }

            if (csvData.FooterRight) {
                AddTextCell(table, headerFooterString, fontRegular, PdfPCell.ALIGN_RIGHT);
            } else {
                AddEmptyCell(table);
            }

            doc.Add(table);

        }

    }
}