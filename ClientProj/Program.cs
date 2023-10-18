using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace ClientProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<BloodPressureSample> _bloodPressureSamples = new BlockingCollection<BloodPressureSample>();
            BloodPressureRead _BPR = new(_bloodPressureSamples);
            ClientPressureReader _CPR = new(_bloodPressureSamples);

            Console.WriteLine("Press Space To Start Client");
            var readkey = Console.ReadKey(false);

            while (readkey.Key != ConsoleKey.Spacebar)
            {
                readkey = Console.ReadKey(false);
            }

            Thread t1 = new Thread(_BPR.Run);
            Thread t2 = new Thread(_CPR.Run);
            t1.Start();
            t2.Start();
            Console.WriteLine("Press q to close client");

            while (readkey.Key != ConsoleKey.Q)
            {
                readkey = Console.ReadKey(false);
            }

            _BPR.run = false;
            t1.Join(10000);
            t2.Join(10000);
            Console.WriteLine("Finished application");
        }
    }
}