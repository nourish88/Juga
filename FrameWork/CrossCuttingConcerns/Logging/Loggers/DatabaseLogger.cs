using Framework.CrossCuttingConcerns.Logging.Log4Net;

namespace Framework.CrossCuttingConcerns.Logging.Loggers
{
    public class DatabaseLogger : LoggerServiceBase
    {
        public DatabaseLogger() : base("DatabaseLogger")
        {
        }
    }
}
