using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace PDFModifierCSV {
    public partial class mainForm : Form {

        private CSVProcessingService csvProcessingService;

        private PDFCreatorService pdfCreatorService;

        public mainForm() {
            InitializeComponent();

            csvProcessingService = new CSVProcessingService();
            pdfCreatorService = new PDFCreatorService();

            Logger.Instance.OnLogAdded += onLogAdded;

        }

        delegate void AppendTextCallback(string text);

        private void onLogAdded(string msg) {
            if (logTextBox.InvokeRequired) {
                var callback = new AppendTextCallback(onLogAdded);
                logTextBox.Invoke(callback, new object[] { msg });
            } else {
                logTextBox.AppendText(msg + "\n");
            }
        }

        private void startButton_Click(object sender, EventArgs e) {
            string fileName = csvPathTextBox.Text;
            if (fileName == "") {
                MessageBox.Show("Please select CSV file!");
                return;
            }

            if (!File.Exists(fileName)) {
                MessageBox.Show("CSV file does not exist!");
                return;
            }

            CSVData data = csvProcessingService.ProcessCSV(fileName);
            if (data != null) {
                data.HeaderLeft = headLeftCheckBox.Checked;
                data.HeaderCenter = headCenterCheckBox.Checked;
                data.HeaderRight = headRightCheckbox.Checked;

                data.FooterLeft = footLeftCheckbox.Checked;
                data.FooterCenter = footCenterCheckbox.Checked;
                data.FooterRight = footRightCheckbox.Checked;

                var thread = new Thread(new ThreadStart(delegate () {
                    pdfCreatorService.ProcessCSVData(data);
                }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();

            }

        }

        private void selCVSPathButton_Click(object sender, EventArgs e) {
            OpenFileDialog openDialog = new OpenFileDialog() {
                CheckFileExists = true,
                DefaultExt = ".csv",
                Filter = "CSV File (*.csv) |*.csv"
            };

            if (openDialog.ShowDialog() == DialogResult.OK) {
                csvPathTextBox.Text = openDialog.FileName;
            }

        }
    }
}
