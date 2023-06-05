using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class ExitCommand : AbstractCommand
    {
        public Circuit circuit;
        public Server server;
        public ExitCommand(Circuit circuit, Server server)
        {
            this.circuit = circuit;
            this.server = server;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            circuit.IsRunning = false;
            server.RemoveCircuit(circuit);
        }
    }
}
