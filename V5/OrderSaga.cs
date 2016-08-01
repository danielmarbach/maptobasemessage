using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Saga;

public class OrderSaga :
    Saga<OrderSagaData>,
    IAmStartedByMessages<StartOrder>,
    IHandleMessages<CompleteOrder>
{
    static ILog log = LogManager.GetLogger<OrderSaga>();

    protected override void ConfigureHowToFindSaga(SagaPropertyMapper<OrderSagaData> mapper)
    {
        mapper.ConfigureMapping<BaseMessage>(message => message.OrderId)
                .ToSaga(sagaData => sagaData.OrderId);
    }

    public void Handle(StartOrder message)
    {
        Data.OrderId = message.OrderId;
        log.Info($"Saga with OrderId {Data.OrderId} received StartOrder with OrderId {message.OrderId}");
        var completeOrder = new CompleteOrder
        {
            OrderId = Data.OrderId
        };
        Bus.SendLocal(completeOrder);
    }

    public void Handle(CompleteOrder message)
    {
        log.Info($"Saga with OrderId {Data.OrderId} received CompleteOrder with OrderId {message.OrderId}");
        MarkAsComplete();
    }

}