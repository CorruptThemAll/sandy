using System.Collections.Concurrent;
using ProjectStrat.Interface;
using ProjectStrat.Abstract;

namespace ProjectStrat.IndependentObjects;
public class HeartReaderConsumer : HeartReaderSubject, IHeartReaderConsumer
{
    private readonly BlockingCollection<HeartRateBlock> heartRateBlock;
    public double HeartRate { get; set; }
    public bool heartRateState = false;
    public HeartReaderConsumer(BlockingCollection<HeartRateBlock> heartRateBlock)
    {
        this.heartRateBlock = heartRateBlock;
    }

    public void ConsumeHeartRate()
    {
        while (!heartRateBlock.IsCompleted)
        {
            if(heartRateBlock.TryTake(out var item))
            {
                HeartRate = item.Value;
                this.Notify();
            }
        }
        heartRateState = true;
    }
}
