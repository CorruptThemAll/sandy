using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using ProjectStrat.Interface;

namespace ProjectStrat.IndependentObjects
{
    public class HeartReaderProducer : IHeartRateReaderProducer
    {
        private readonly BlockingCollection<HeartRateBlock> blockCollectionHR;
        private bool _disposed = false;
        private readonly HeartRateSensor _sensor;
        private readonly UserInput _userInput;
        public HeartReaderProducer(BlockingCollection<HeartRateBlock> blockCollectionHR, HeartRateSensor heartRateSensor, UserInput userInput)
        {
            this.blockCollectionHR = blockCollectionHR;
            _sensor = heartRateSensor;
            _userInput = userInput;
        }
        public void AddHeartRate()
        {
            while (_disposed == false)
            {
                var heartBlock = new HeartRateBlock
                {
                    Value = (int)_sensor.SampleHeartRate()
                };
                blockCollectionHR.Add(heartBlock);
                Debug.WriteLine("HeartRateProducer");
                Thread.Sleep(500);
                if (_userInput.exitKey == true)
                {
                    Debug.WriteLine("Breaks producer from the inside.");
                    break;
                }
            }
            Debug.WriteLine("producer thread dead");
            Console.WriteLine("Exited");
        }
        public void ExitThread()
        {
            _disposed = true;
            Debug.WriteLine("Disposing");
        }
    }
}