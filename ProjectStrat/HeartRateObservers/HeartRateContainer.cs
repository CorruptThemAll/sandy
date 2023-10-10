using ProjectStrat.Abstract;
using ProjectStrat.IndependentObjects;
using ProjectStrat.Interface;

namespace ProjectStrat.HeartRateObservers
{
    internal class HeartRateContainer : IHeartRateReaderObserver
    {
        public HeartReaderConsumer HeartReader { get; }
        public HeartRateContainer(HeartReaderConsumer heartReader)
        {
            HeartReader = heartReader;
            heartReader.Attach(this);
        }
        public void Update()
        {

        }
    }
}