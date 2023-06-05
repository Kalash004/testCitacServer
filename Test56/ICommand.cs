using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public interface ICommand
    {
        void Execute(object? parameter);
    }
}
