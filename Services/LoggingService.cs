namespace Fylth.Services;

public class LoggingService
{
    private List<string> messages = new();

    public LoggingService()
    {
        LogMessage("TRACE", "Fylth message service is ready");
    }

    private void LogMessage(string level, string message)
    {
        messages.Add($"[{DateTime.Now}] {level}: {message}");
    }

    public void Debug()
    {
        
    }
}