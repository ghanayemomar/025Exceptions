using _025Exceptions;

partial class Program
{
    static void Main(String[] args)
    {
        var delivery = new Delivery { Id = 1, CustomerName = "Issam A.", Address = "123 Street" };
        var service = new DeliveryService();
        service.Start(delivery);
        Console.WriteLine(delivery);
        Console.ReadKey();
    }
}