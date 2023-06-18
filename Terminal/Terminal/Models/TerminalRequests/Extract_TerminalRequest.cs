using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class Extract_TerminalRequest: TerminalRequest
    {
        public Extract_TerminalRequest() 
        {
            CommandName = "extract";
        }
        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            string[] parametrs = commandBody.Split(' ');
            string zipUrl = parametrs[0];
            string dirUrl = parametrs[1];
            ZipFile.ExtractToDirectory(zipUrl, dirUrl);
            Console.WriteLine($"{zipUrl} extracted to {dirUrl}");
        }
    }
}
