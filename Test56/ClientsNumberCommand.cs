using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test56
{
    public class ClientsNumberCommand : AbstractCommand
    {
        private Server server;
        public ClientsNumberCommand(Server server)
        {
            this.server = server;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Result = this.server.AmoutOfUsers.ToString();
        }
    }
}
