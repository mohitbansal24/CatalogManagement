using NLog;

namespace CatalogService.Manager
{
    public static class LoggerManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void Error(string log)
        {
            logger.Error(log);
        }

        public static void Debug(string log)
        {
            logger.Debug(log);
        }

        public static void Trace(string log)
        {
            logger.Trace(log);
        }

        public static void Warning(string log)
        {
            logger.Warn(log);
        }

        public static void Info(string log)
        {
            logger.Info(log);
        }
    }
}
