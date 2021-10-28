using Logger.Enums;
using Logger.Layouts;
using System;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.CanAppend(reportLevel))
            {
                string content = string.Format(this.layout.Template, date, reportLevel, message);

                Console.WriteLine(content);
                this.MessagesCount += 1;
            }
        }
    }
}
