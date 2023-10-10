using ProjectStrat.IndependentObjects;
using ProjectStrat.Interface;

namespace ProjectStrat.HeartRateObservers
{
    internal class Processer : IHeartRateReaderObserver
    {
        public HeartReaderConsumer HeartReader { get; }

        public Processer(HeartReaderConsumer heartRateConsumer)
        {
            HeartReader = heartRateConsumer;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}