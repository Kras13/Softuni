﻿using Logger.Enums;
using Logger.Layouts;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        protected int MessagesCount { get; set; }

        public abstract void Append(string date, ReportLevel reportLevel, string message);

        protected bool CanAppend(ReportLevel reportLevel)
        {
            return reportLevel >= this.ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}," +
                $" Report level: {this.ReportLevel}, Messages appended: {this.MessagesCount}";
        }
    }
}
