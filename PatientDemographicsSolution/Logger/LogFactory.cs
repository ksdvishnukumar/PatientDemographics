namespace Logger
{
    public class LogFactory
    {
        private static LogBase logger = null;
        public static void Log(LogType logType, LogMode dest, string message)
        {
            switch (dest)
            {
                case LogMode.TextFile:
                    logger = new TextFileLogger();
                    logger.WriteToLog(logType, message);
                    break;
                case LogMode.DB:
                    logger = new DBLogger();
                    logger.WriteToLog(logType, message);
                    break;
                default:
                    return;
            }
        }
    }
}
