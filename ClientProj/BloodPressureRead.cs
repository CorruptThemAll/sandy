using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace ClientProj
{
    public struct BloodPressureSample
    {
        public double bloodPressure { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
    public class BloodPressureRead
    {
        private readonly BlockingCollection<BloodPressureSample> bloodPressureSample;
        private BloodPressureSensor sensor; 
        public bool run;
        public BloodPressureRead(BlockingCollection<BloodPressureSample> bloodPressureSample)
        {
            this.bloodPressureSample = bloodPressureSample;
            sensor = new BloodPressureSensor();
            run = true;  
        }

        public void Run() => AddSample();

        private void AddSample()
        {
            while (run)
            {
                var takenSample = sensor.Sample();
                bloodPressureSample.Add(new BloodPressureSample { bloodPressure = takenSample, CurrentDateTime = DateTime.Now});
            }
            bloodPressureSample.CompleteAdding();
        }
    }
}