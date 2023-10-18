using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Server
{
    public struct BloodPressureSample
    {
        public double bloodPressure { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }

    public class ServerPressureReader
    {
        private readonly BlockingCollection<BloodPressureSample> bloodPressureSample;
        public bool run = true;
        public ServerPressureReader(BlockingCollection<BloodPressureSample> bloodPressureSample)
        {
            this.bloodPressureSample = bloodPressureSample;
        }

        public void Run() => Read();

        private void Read()
        {
            IPAddress iPAddress = IPAddress.Any;
            IPEndPoint iPPEndPoint = new IPEndPoint(iPAddress, 13000);
            using Socket listener = new(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(iPPEndPoint);
            listener.Listen();
            var handler = listener.Accept();
            var buffer = new byte[1024];
            while (run)
            {
                try
                {
                    var messagebytes = handler.Receive(buffer, SocketFlags.None);
                    var message = Encoding.UTF8.GetString(buffer, 0, messagebytes);
                    var recievedBloodPS = JsonSerializer.Deserialize<BloodPressureSample>(message);
                    Debug.WriteLine("Recieved message");

                    bloodPressureSample.Add(recievedBloodPS);
                } catch (Exception ex) { Debug.WriteLine(ex.ToString()); }
            }
            bloodPressureSample.CompleteAdding();
            listener.DisconnectAsync(new SocketAsyncEventArgs());
            listener.Shutdown(SocketShutdown.Both);
        }
    }
}