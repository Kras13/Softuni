using Logger.Enums;

namespace Logger.Appenders
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string date, ReportLevel reportLevel, string message);
    }
}
