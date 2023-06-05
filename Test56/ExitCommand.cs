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
        public ExitCommand(Circuit circuit)
        {
            this.circuit = circuit;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            circuit.IsRunning = false;
        }
    }
}
