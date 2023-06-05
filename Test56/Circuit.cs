using OneOf;
using System.Net.Sockets;
using System.Text;

namespace Test56
{
    public class Circuit
    {
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;
        private Citac citac;
        private Dictionary<string, AbstractCommand> commands = new Dictionary<string, AbstractCommand>();
        private bool isRunning;
        private Server server;

        public bool IsRunning { get => isRunning; set => isRunning = value; }
        public Server Server { get => server; set => server = value; }

        public Circuit(TcpClient tcpClient, Server server, Citac citac)
        {
            this.tcpClient = tcpClient;
            CreateCommands(tcpClient, citac, server);
            reader = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);
            writer = new StreamWriter(tcpClient.GetStream(), Encoding.UTF8);
            this.server = server;
            this.citac = citac;
        }

        private void CreateCommands(TcpClient tcpClient, Citac citac, Server server)
        {
            commands.Add("up", new AddCommand(citac));
            commands.Add("down", new RemoveCommand(citac));
            commands.Add("value", new ValueCommand(citac));
            commands.Add("exit", new ExitCommand(this,server));
            commands.Add("unknown", new UnknownCommand());
            commands.Add("help", new HelpCommand(commands));
            commands.Add("clients", new ClientsNumberCommand(server));
        }

        public bool Run()
        {
            isRunning = true;
            while (isRunning)
            {
                try
                {
                    ClientFunction();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    SendMessage($"Error happened, your circuit was closed. ErrCode: {e.Message}");
                    isRunning = false;
                }
            }
            return isRunning;
        }

        private void ClientFunction()
        {
            string? data = null;
            string? returnData = null;
            bool isConnected = true;
            data = reader.ReadLine();
            if (data != null)
            {
                data = data.ToLower();
                returnData = ReadAndExecuteCommand(data);
                SendMessage(returnData);
            }
        }

        private string ReadAndExecuteCommand(string data)
        {
            if (data == null) return "";
            if (!commands.ContainsKey(data)) return $"Command {data} was not found, use command for list of commands";
            OneOf<string, bool> result = ExecuteCommand(commands[data]);
            string? returnData = null;
            bool executed;
            if (result.TryPickT0(out returnData, out executed)) return returnData;
            if (executed) return $"Command {data} was executed successfuly";
            return $"Command {data} was NOT executed";
        }


        /// <summary>
        /// Executes command depending on the string from client
        /// </summary>
        /// <param name="command">command to execute</param>
        /// <returns>One of (string, bool) case: bool => returns if command was executed or not. case: string => text to return to the client </returns>
        private OneOf<string, bool> ExecuteCommand(AbstractCommand command)
        {
            string? retrunData = null;
            try
            {
                command.Execute(null);
                if (command.Result != null)
                {
                    retrunData = command.Result.ToString();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occurred {e.Message}");
                return false;
            }
            if (retrunData != null) return retrunData;
            return true;
        }

        private void SendMessage(string message)
        {
            writer.WriteLine(message);
            writer.Flush();
        }
    }
}