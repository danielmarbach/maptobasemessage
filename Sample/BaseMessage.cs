using NServiceBus;

public abstract class BaseCompleteOrder :
    IMessage
{
    public string OrderId { get; set; }
}