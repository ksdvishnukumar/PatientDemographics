using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public enum LogMode
    {
        TextFile,
        DB
    }

    public enum LogType
    {
        Info,
        Error,
        Debug
    }

    public abstract class LogBase
    {
        public abstract void WriteToLog(LogType logType,string message);
    }
}
