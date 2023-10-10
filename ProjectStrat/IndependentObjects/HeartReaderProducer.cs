using System.Collections.Concurrent;
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
                Thread.Sleep(10);
            }
            Console.WriteLine("Exited");
            Thread.CurrentThread.Abort();
        }
        public void ExitThread()
        {
            _disposed = true;
        }
    }
}