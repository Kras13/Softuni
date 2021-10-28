using Logger.Enums;
using Logger.Layouts;
using System.IO;
using System;
using Logger.Loggers;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile)
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (this.CanAppend(reportLevel))
            {
                string content = string.Format(this.layout.Template, date, reportLevel, message)
                + Environment.NewLine;

                logFile.Write(content);

                this.MessagesCount += 1;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
