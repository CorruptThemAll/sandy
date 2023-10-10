using ProjectStrat.IndependentObjects;
using ProjectStrat.Interface;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace ProjectStrat.HeartRateObservers
{
    internal class Log : IHeartRateReaderObserver
    {
        public HeartReaderConsumer HeartReader { get; }
        readonly FileStream fs = new("Log.txt", FileMode.Create);
        readonly StreamWriter sw;
        public Log(HeartReaderConsumer heartReader)
        {
            sw = new StreamWriter(fs);
            HeartReader = heartReader;
            heartReader.Attach(this);
        }
        public void Update()
        {
            if (fs.CanWrite) 
            {
                sw.WriteLine(HeartReader.HeartRate.ToString());
            } else
            {
                Close();
            } 
        }
        public void Close() => fs.Close();
    }
}