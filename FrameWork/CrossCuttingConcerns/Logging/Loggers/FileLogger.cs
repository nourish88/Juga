using Framework.CrossCuttingConcerns.Logging.Log4Net;

namespace Framework.CrossCuttingConcerns.Logging.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {
        }
    }
}
