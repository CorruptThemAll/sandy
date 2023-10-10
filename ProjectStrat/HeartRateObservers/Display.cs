using ProjectStrat.IndependentObjects;
using ProjectStrat.Interface;

namespace ProjectStrat.HeartRateObservers
{
    internal class Display : IHeartRateReaderObserver
    {
        public HeartReaderConsumer HeartReader { get; }
        public Display(HeartReaderConsumer heartReader)
        {
            HeartReader = heartReader;
            HeartReader.Attach(this);
        }
        public void Update()
        {
            Console.WriteLine(HeartReader.HeartRate);
        }
    }
}