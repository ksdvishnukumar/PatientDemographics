namespace Logger
{
    public class DBLogger:LogBase
    {
        string connectionString = string.Empty;
        public override void WriteToLog(LogType logType,string message)
        {
            //DB Logging Implmementation
        }
    }
}
