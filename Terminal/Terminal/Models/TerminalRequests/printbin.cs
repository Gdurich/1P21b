using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class printbin : TerminalRequest
    {
        public printbin()
        {
            CommandName = "printbin";
        }
        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            Console.WriteLine("Lox");
        }
    }
}
