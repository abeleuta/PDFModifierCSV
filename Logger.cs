
using System;
using System.IO;
using System.Reflection;

namespace PDFModifierCSV {
    public delegate void LogAdded(string msg);

    class Logger {

        public event LogAdded OnLogAdded;

        private string logFile;

        public static Logger Instance {
            get {
                return instance;
            }
        }

        private static Logger instance = new Logger();

        private Logger() {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            logFile = Path.GetDirectoryName(path) + "\\Logging.txt";
        }

        public void Log(string message) {
            string date = DateTime.Now.ToString();
            string msg = date + ": " + message;
            if (OnLogAdded != null) {
                OnLogAdded.Invoke(msg);
            }

            System.IO.File.AppendAllText(logFile, msg + "\r\n");
        }

    }

}
