using System.Collections.Concurrent;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<BloodPressureSample> bloodPressureSample = new BlockingCollection<BloodPressureSample>();
            ServerPressureReader serverPressureReader = new(bloodPressureSample);
            BloodPressureReaderTaker bloodPressureReaderTaker = new(bloodPressureSample);
            Display display = new Display();
            bloodPressureReaderTaker.bloodPressureEvent += display.Log;
            Console.WriteLine("To stop server press escape");
            Thread t1 = new Thread(serverPressureReader.Run);
            Thread t2 = new Thread(bloodPressureReaderTaker.Run);
            t1.Start();
            t2.Start();
            while(true)
            {
                if(Console.ReadKey(false).Key == ConsoleKey.Escape)
                {
                    serverPressureReader.run = false;
                    break;
                }
            }
            t1.Join(10000);
            t2.Join(10000);
            Console.WriteLine("Closed");
        }
    }
}