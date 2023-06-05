using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class HelpCommand : AbstractCommand
    {
        private Dictionary<string, AbstractCommand> commands;
        public HelpCommand(Dictionary<string, AbstractCommand> commands)
        {
            this.commands = commands;
        }

        public override bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            Result = "";
            foreach (KeyValuePair<string,AbstractCommand> valuePair in commands)
            {
                Result = $"{Result}- {valuePair.Key} {valuePair.Value.Description}";
            }
        }
    }
}
