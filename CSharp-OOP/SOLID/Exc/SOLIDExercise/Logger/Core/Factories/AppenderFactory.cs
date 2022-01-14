using Logger.Appenders;
using Logger.Enums;
using Logger.Layouts;
using Logger.Loggers;
using System;

namespace Logger.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender = null;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = reportLevel
                    };
                    break;
                default:
                    throw new ArgumentException("Trying to create invalid appender");
            }

            return appender;
        }
    }
}
