using System.IO;
using System.Configuration;
using System;

namespace Logger
{
    public class TextFileLogger : LogBase
    {
        //Readonly object is used ensure that  more than one user should not lock the file in a SIngle threaded environment
        protected readonly object lockObj = new object();
        //Getting the Filepath from the COnfiguration file
        private string filePath = ConfigurationManager.AppSettings["LogFilePath"].ToString();
        public override void WriteToLog(LogType logType, string message)
        {
            //Preparing the File name for the Log file
            string fileName = string.Format("{0}.txt", DateTime.Now.ToString("ddMMyyyyhh"));
            lock (lockObj)
            {
                //Creating the Streamwriter to write the log message in to the file
                using (StreamWriter streamWriter = new StreamWriter(filePath + fileName, true))
                {
                    streamWriter.WriteLine($"LogType : {logType.ToString()} \t  Time : {DateTime.Now.ToString("dd/MM/yyyy")}");
                    streamWriter.WriteLine($"Message : {message}");
                    streamWriter.Close();
                }
            }
        }
    }
}
