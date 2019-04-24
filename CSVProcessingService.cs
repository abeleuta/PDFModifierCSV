using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace PDFModifierCSV {
    class CSVProcessingService {
        public CSVData ProcessCSV(string fullPath) {

            using (TextFieldParser parser = new TextFieldParser(fullPath)) {
                CSVData data = new CSVData() {
                    FileName = fullPath
                };

                parser.SetDelimiters(new string[] { "," });

                //skip headers
                parser.ReadLine();

                while (!parser.EndOfData) {
                    string[] fields = parser.ReadFields();

                    List<string> inputImages = new List<string>();
                    string[] imagePaths = fields[7].Split(new char[] { '|' });
                    inputImages.AddRange(imagePaths);

                    InputRow row = new InputRow() {
                        PdfOut = fields[0],
                        Bookmark = fields[1],
                        HeaderFooterMetadata = "Lot Number:" + fields[2] + " Part Number:" + fields[4],
                        XmlFile = fields[3],
                        ItemNumber = fields[4],
                        LotNumber = fields[5],
                        CertType = fields[6],
                        InputPDFs = inputImages
                    };

                    data.InputRows.Add(row);
                }

                return data;
            }

        }
    }
}
