using System.IO;
using Framework.CrossCuttingConcerns.Logging.Log4Net;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;

namespace Framework.CrossCuttingConcerns.Logging.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {
           
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent,Formatting.Indented);
            writer.WriteLine(json);
        }
    }
}
