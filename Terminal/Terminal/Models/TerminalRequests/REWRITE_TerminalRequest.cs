using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class REWRITE_TerminalRequest : TerminalRequest
    {
        public REWRITE_TerminalRequest() {
            CommandName = "rewrite";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            try
            {
                string[] args = commandBody.Split(' ', 4);

                string filename = "";
                string text = "";

                for (int i = 0; i < args.Length; i++)
                {
                    switch (args[i])
                    {
                        case "-f":
                            filename = args[i + 1];
                            break;
                        case "-i":
                            text = args[i + 1];
                            break;
                    }
                }

                if (filename == "" || text == "")
                {
                    throw new Exception();
                }

                string fullPath = CommandHandler.CurrentDirectoryPath + '/' + filename;

                using (StreamWriter sw = new StreamWriter(fullPath))
                {
                    sw.WriteLine(text);
                }

            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            

            base.Execute(handler, commandBody);
        }
    }
}
