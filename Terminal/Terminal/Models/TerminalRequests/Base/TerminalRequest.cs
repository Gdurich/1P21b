using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;

namespace Terminal.Models.TerminalRequests.Base
{
    public class TerminalRequest
    {
        public string CommandName { get; protected set; }
        public virtual void Execute(CommandHandler handler, string commandBody = "") 
        {
            Console.WriteLine($"Executed: {CommandName} {commandBody}");
        }
    }
}
