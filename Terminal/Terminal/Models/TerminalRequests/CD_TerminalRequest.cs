using Terminal.Handlers;
using Terminal.Helpers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class CD_TerminalRequest : TerminalRequest
    {
        public CD_TerminalRequest()
        {
            CommandName = "cd";
        }
        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            try
            {
                switch (commandBody)
                {
                    case "":
              
                        throw new Exception("Enter command body");
                    case "..":
                        if (!handler.SetCurrentDirectory(CommandHandler.CurrentDirectoryPath.Substring(0, CommandHandler.CurrentDirectoryPath.LastIndexOf('\\')))) throw new Exception("Directory not exists");
                        break;
                    default:
                        if (!handler.SetCurrentDirectory(commandBody)) throw new Exception("Directory not exists");
                        break;
                }
                //if (commandBody == "") throw new Exception("Enter command body");
                //if (commandBody == "..")
                //{
                //    if (!handler.SetCurrentDirectory(CommandHandler.CurrentDirectoryPath.Substring(0, CommandHandler.CurrentDirectoryPath.LastIndexOf('\\')))) throw new Exception("Directory not exists");
                //    return;
                //}
                //if (!handler.SetCurrentDirectory(commandBody)) throw new Exception("Directory not exists");

            }
            catch (Exception ex)
            {
                ConsoleHelper.WriteColorLine($"Error: {ex.Message}", ConsoleColor.DarkRed);
            }
        }
    }
}
