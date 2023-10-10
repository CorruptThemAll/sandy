using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using MathNet.Numerics.Distributions;
using ProjectStrat.IndependentObjects;
using ProjectStrat.HeartRateObservers;
using System.Runtime.CompilerServices;

namespace ProjectStrat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Test Program";
            Thread tconsumer, tproducer;
            BlockingCollection<HeartRateBlock> blockCollectionHR = new();
            var heartSense = new HeartRateSensor();
            var heartRateProducer = new HeartReaderProducer(blockCollectionHR, heartSense);
            var heartRateConsumer = new HeartReaderConsumer(blockCollectionHR);
            var userInput = new UserInput();
            userInput.KeyEvent += heartSense.Increase;
            userInput.KeyEvent += heartSense.Decrease;
            userInput.KeyEvent += userInput.CloseProgram;
            var heartRateContainer = new HeartRateContainer(heartRateConsumer);
            var log = new Log(heartRateConsumer);
            var processer = new Processer(heartRateConsumer);
            var diplay = new Display(heartRateConsumer);

            tconsumer = new(heartRateProducer.AddHeartRate)
            {
                Name = "Consumer"
            };
            tproducer = new(heartRateConsumer.ConsumeHeartRate)
            {
                Name = "Producer"
            };
            try
            {
                tproducer.Start();
                tconsumer.Start();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            while (!userInput.exitKey)
            {
                userInput.ButtonPress(Console.ReadKey().KeyChar);
                Thread.Sleep(10);
            }
            heartRateProducer.ExitThread();
            tproducer.Join();
            tconsumer.Join();

            Console.WriteLine("done");
        }
    }
}