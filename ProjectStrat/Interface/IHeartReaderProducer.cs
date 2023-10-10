using ProjectStrat.IndependentObjects;
using System.Collections.Concurrent;


namespace ProjectStrat.Interface;
public interface IHeartReaderProducer
{
    protected BlockingCollection<HeartRateBlock> HeartRateBlock { get; set; }
    public void Produce();
}
