using NServiceBus;

public class BaseMessage :
    IMessage
{
    public string OrderId { get; set; }
}