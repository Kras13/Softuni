using Logger.Appenders;
using Logger.Core.Factories;
using Logger.Enums;
using Logger.Layouts;
using Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ILayout> layoutByType = new Dictionary<string, ILayout>()
            {
                {nameof(SimpleLayout),new SimpleLayout() },
                {nameof(XmlLayout),new XmlLayout() }
            };

            IAppenderFactory appenderFactory = new AppenderFactory();

            int n = int.Parse(Console.ReadLine());

            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderParts = Console.ReadLine().Split();

                string appenderType = appenderParts[0];
                string layoutType = appenderParts[1];
                ReportLevel reportLevel = appenderParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderParts[2], true)
                    : ReportLevel.Info;
                // Appender Factory -> Factory Pattern

                IAppender appender = appenderFactory
                    .CreateAppender(appenderType, layoutByType[layoutType], reportLevel);

                appenders[i] = appender;
            }

            ILogger logger = new Loggers.Logger(appenders);

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split("|", StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                switch (reportLevel)
                {
                    case ReportLevel.Info:
                        logger.Info(date, message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warning(date, message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(date, message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(date, message);
                        break;
                    case ReportLevel.Fatal:
                        logger.Fatal(date, message);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Logger info");
            Console.WriteLine(logger);
        }
    }
}
