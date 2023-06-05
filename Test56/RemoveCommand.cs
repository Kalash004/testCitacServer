using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    internal class RemoveCommand : AbstractCommand
    {
        private Citac citac;
        public RemoveCommand(Citac citac)
        {
            this.citac = citac;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            try
            {
               Result = citac.RemoveOne().ToString();
            } catch (Exception e)
            {
                Result = $"Didnt execute: {e.Message}";
            }
        }
    }
}
