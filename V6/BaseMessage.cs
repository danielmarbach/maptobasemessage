using NServiceBus;

public abstract class BaseMessage :
    IMessage
{
    public string OrderId { get; set; }
}