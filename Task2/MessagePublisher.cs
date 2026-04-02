using System;

public delegate void MessageSentHandler(string message);

public class MessagePublisher
{
    public event MessageSentHandler MessageSent;

    public void Send(string message)
    {
        MessageSent?.Invoke(message);
    }
}