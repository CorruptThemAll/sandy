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
            Thread tconsumer, tproducer;
            BlockingCollection<HeartRateBlock> blockCollectionHR = new();
            var heartSense = new HeartRateSensor();
            var userInput = new UserInput();
            userInput.KeyEvent += heartSense.Increase;
            userInput.KeyEvent += heartSense.Decrease;
            userInput.KeyEvent += userInput.CloseProgram;

            var heartRateProducer = new HeartReaderProducer(blockCollectionHR, heartSense, userInput);
            var heartRateConsumer = new HeartReaderConsumer(blockCollectionHR);
            var heartRateContainer = new HeartRateContainer(heartRateConsumer);
            var log = new Log(heartRateConsumer);
            var processer = new Processer(heartRateConsumer);
            var diplay = new Display(heartRateConsumer);

            tproducer = new(heartRateConsumer.ConsumeHeartRate)
            {
                Name = "Producer",
                IsBackground = true,
            };
            tconsumer = new(heartRateProducer.AddHeartRate)
            {
                Name = "Consumer",
                IsBackground = true,
            };
            
            tproducer.Start();
            tconsumer.Start();
           

            while (!userInput.exitKey)
            {
                userInput.ButtonPress(Console.ReadKey().KeyChar);
                Thread.Sleep(10);
            }
            
            heartRateProducer.ExitThread();
            
            tproducer.Join(TimeSpan.FromSeconds(3));
            tconsumer.Join();

            Console.WriteLine("done");
        }
    }
}