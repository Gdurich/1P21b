using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Helpers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    public class Append : TerminalRequest
    {
        public Append()
        {
            CommandName = "append";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            try {
                if (commandBody.StartsWith("-"))
                {
                    char key = commandBody[1];

                    switch (key)
                    {
                        case 'b':
                            Console.WriteLine("Edit file at the beginning");
                            break;
                        case 'c':
                            Console.WriteLine("Edit file at the center");
                            break;
                        case 'e':
                            Console.WriteLine(" Edit file at the end");
                            break;
                        default:
                            throw new Exception("Enter command body");              
                    }
                }
                else
                {
                    Console.WriteLine($"Executed: {CommandName} {commandBody}");
                }
            }
            catch (Exception ex) 
            {
                ConsoleHelper.WriteColorLine($"Error: {ex.Message}", ConsoleColor.DarkRed);
            }
            }
    }
}