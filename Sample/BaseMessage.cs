using NServiceBus;

public class BaseCompleteOrder :
    IMessage
{
    public string OrderId { get; set; }
}