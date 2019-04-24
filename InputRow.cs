using System.Collections.Generic;

namespace PDFModifierCSV {
    class InputRow {

        public string PdfOut { get; set; }

        public string Bookmark { get; set; }

        public string HeaderFooterMetadata { get; set; }

        public string XmlFile { get; set; }

        public string ItemNumber { get; set; }

        public string LotNumber { get; set; }

        public string CertType { get; set; }

        public List<string> InputPDFs { get; set; }

    }

}