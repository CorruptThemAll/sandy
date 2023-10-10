using System.Collections.Concurrent;
using System.Diagnostics;
using ProjectStrat.Interface;

namespace ProjectStrat.IndependentObjects
{
    public class HeartReaderProducer : IHeartRateReaderProducer
    {
        private readonly BlockingCollection<HeartRateBlock> blockCollectionHR;
        private bool _disposed = false;
        private readonly HeartRateSensor _sensor;
        public HeartReaderProducer(BlockingCollection<HeartRateBlock> blockCollectionHR, HeartRateSensor heartRateSensor)
        {
            this.blockCollectionHR = blockCollectionHR;
            _sensor = heartRateSensor;
        }
        public void AddHeartRate()
        {
            while (!_disposed)
            {
                var heartBlock = new HeartRateBlock
                {
                    Value = (int)_sensor.SampleHeartRate()
                };
                blockCollectionHR.Add(heartBlock);
                Debug.WriteLine("HeartRateProducer");
                Thread.Sleep(500);
            }
            Console.WriteLine("Exited");
        }
        public void ExitThread()
        {
            _disposed = true;
            Debug.WriteLine("Disposing");
        }
    }
}