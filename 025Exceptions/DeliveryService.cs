namespace _025Exceptions
{
    public class DeliveryService
    {
        private readonly static Random random = new Random();
        public void Start(Delivery delivery)
        {
            try
            {
                Process(delivery);
                Ship(delivery);
                Transit(delivery);
                Deliver(delivery);
            }
            catch (AccidentException ex)
            {
                Console.WriteLine($"There was an accident preventing at {ex.Location} us from delivering your parcel  : {ex.Message}");
                delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deliver Fails due to : {ex.Message}");
                delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
            }
            finally
            {
                Console.WriteLine("END");
            }
        }

        private void Process(Delivery delivery)
        {
            FakeIt("Processing");
            delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
        }

        private void Ship(Delivery delivery)
        {
            FakeIt("Shipping");
            if (random.Next(1, 3) == 1)
            {
                throw new InvalidOperationException("Parcel is damged during the loading process");
            }
            delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
        }

        private void Transit(Delivery delivery)
        {
            FakeIt("On Its way");
            if (random.Next(1, 1) == 1)
            {
                throw new AccidentException("354 some another street", "ACCEDENT!!!");
            }
            delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
        }

        private void Deliver(Delivery delivery)
        {
            FakeIt("Delivering");
            delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
        }
        private void FakeIt(string title)
        {
            Console.Write(title);
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.Write(".");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine(".");
        }
    }
}
