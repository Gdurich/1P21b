using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class Help_TerminalRequest: TerminalRequest
    {
        public Help_TerminalRequest() 
        {
            CommandName = "help";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            foreach (var item in handler.GetCommandList())
            {
                Console.WriteLine($"    {item.CommandName}");
            }
        }
    }
}
