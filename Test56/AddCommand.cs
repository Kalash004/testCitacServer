using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class AddCommand : AbstractCommand
    {
        private Citac citac;
        public AddCommand(Citac citac)
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
                this.Result = citac.AddOne().ToString();
            } catch (Exception e)
            {
                Result = $"Didnt execute: {e.Message}";
            }
        }
    }
}
