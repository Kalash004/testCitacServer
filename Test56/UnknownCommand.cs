using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class UnknownCommand : AbstractCommand
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Result = "Unknown command";
        }
    }
}
