using Server.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Server
{
    public class Display : IDisplay
    {
        public void Log(object? o, BloodPressureSampleEventArgs e)
        {
            Console.WriteLine($"Bloodpressure in mmHg: {e.Sample}, taken on this date and time: {e.Time}");
        }
    }
}