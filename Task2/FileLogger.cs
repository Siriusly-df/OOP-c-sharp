using System;
using System.IO;

public class FileLogger
{
    private string logFilePath;

    public FileLogger(string filePath, MessagePublisher publisher)
    {
        logFilePath = filePath;
        publisher.MessageSent += LogMessage;
    }

    private void LogMessage(string message)
    {
        string logLine = $"[{DateTime.Now}] {message}";
        File.AppendAllText(logFilePath, logLine + Environment.NewLine);
    }
}