using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Server
{
    public class BloodPressureSampleEventArgs : EventArgs
    {
        public double Sample { get; set; }
        public DateTime Time { get; set; }
    }
    public class BloodPressureReaderTaker
    {
        readonly BlockingCollection<BloodPressureSample> bloodPressureSamples;
        public event EventHandler<BloodPressureSampleEventArgs> bloodPressureEvent;
        public BloodPressureReaderTaker(BlockingCollection<BloodPressureSample> bloodPressureSamples)
        {
            this.bloodPressureSamples = bloodPressureSamples;
        }
        public void Run() => TakeSample();
        private void TakeSample()
        {
            while (!bloodPressureSamples.IsCompleted)
            {
                if (bloodPressureSamples.TryTake(out var item))
                {
                    Notify(item);
                }
            }
            Debug.WriteLine("Taking program is finished");
        }
        private void Notify(BloodPressureSample e) => bloodPressureEvent?.Invoke(this, new BloodPressureSampleEventArgs {Sample = e.bloodPressure, Time = e.CurrentDateTime});

    }
}