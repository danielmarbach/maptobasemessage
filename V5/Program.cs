using System;
using NServiceBus;

class Program
{

    static void Main()
    {
        Console.Title = "BaseMessageMappingV5";
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("BaseMessageMappingV5");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.EnableInstallers();
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (var bus = Bus.Create(busConfiguration).Start())
        {
            bus.SendLocal(new StartOrder
                          {
                              OrderId = "123"
                          });
            bus.SendLocal(new StartOrder
                          {
                              OrderId = "456"
                          });
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
