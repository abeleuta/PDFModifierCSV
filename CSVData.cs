using System.Collections.Generic;

namespace PDFModifierCSV {
    internal class CSVData {

        public bool HeaderLeft { get; set; }

        public bool HeaderCenter { get; set; }

        public bool HeaderRight { get; set; }

        public bool FooterLeft { get; set; }

        public bool FooterCenter { get; set; }

        public bool FooterRight { get; set; }

        public CSVData() {
            InputRows = new List<InputRow>();
            HeaderLeft = true;
            HeaderCenter = true;
            HeaderRight = true;
            FooterLeft = true;
            FooterCenter = true;
            FooterRight = true;
        }

        public string FileName { get; set; }

        public List<InputRow> InputRows { get; set; }

    }

}
