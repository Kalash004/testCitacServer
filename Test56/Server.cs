using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class Server
    {
        private TcpListener listener;
        private bool isRunning;
        private List<Thread> threads = new List<Thread>();
        private List<Circuit> runtimeCircuits = new List<Circuit>();
        private Citac citac = new Citac();

        public Server(int port)
        {
            listener = new TcpListener(System.Net.IPAddress.Any, port);
            isRunning = true;
            listener.Start();
            ServerLoop();
        }

        public int AmoutOfUsers { get { return runtimeCircuits.Count; } }

        public void RemoveCircuit(Circuit circuitToRemove)
        {
            runtimeCircuits.Remove(circuitToRemove);
        }

        private void ServerLoop()
        {
            Console.WriteLine("Server Started");
            while (isRunning)
            {
                Console.WriteLine("I am listening for connections on " + IPAddress.Parse(((IPEndPoint)listener.LocalEndpoint).Address.ToString()) + " on port number " + ((IPEndPoint)listener.LocalEndpoint).Port.ToString());
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Accepted a client");
                Circuit circuit = new Circuit(client, this, citac);
                runtimeCircuits.Add(circuit);
                Thread t = new Thread(() => { circuit.Run(); });
                t.Start();
                threads.Add(t);
            }
        }
    }
}
