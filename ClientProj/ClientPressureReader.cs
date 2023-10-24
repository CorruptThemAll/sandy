using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClientProj
{
    public class ClientPressureReader
    {
        private readonly BlockingCollection<BloodPressureSample> bloodPressureSamples;
        public ClientPressureReader(BlockingCollection<BloodPressureSample> bloodPressureSamples)
        {
            this.bloodPressureSamples = bloodPressureSamples;
        }

        public void Run() => Read();

        //Man skal huske at i forhold til projekt, skal denne client ændres til en modtager af beskeder og ikke en sender.
        //Så koden før loop er den koden som connecter til en server.
        private void Read()
        {
            var IPaddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint iPEndPoint = new(IPaddress, 13000);
            using Socket client = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            client.Connect(iPEndPoint);

            while (!bloodPressureSamples.IsCompleted)
            {
                var message = "";
                if(bloodPressureSamples.TryTake(out var sample))
                {
                    message += JsonSerializer.Serialize(sample);
                }
                Debug.WriteLine("Send message");

                try
                {
                    var messagebytes = Encoding.UTF8.GetBytes(message);
                    client.Send(messagebytes);
                }
                catch (Exception ex) { Debug.WriteLine(ex); }

                Thread.Sleep(500);
            }

            client.Shutdown(SocketShutdown.Both);
        }
    }
}