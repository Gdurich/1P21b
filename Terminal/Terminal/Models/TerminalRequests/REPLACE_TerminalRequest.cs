using Terminal.Handlers;
using Terminal.Helpers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class REPLACE_TerminalRequest : TerminalRequest
    {
        public REPLACE_TerminalRequest()
        {
            CommandName = "replace";
        }


        public override void Execute(CommandHandler handler, string commandBody = "")
        {

            base.Execute(handler, commandBody);
        }
    }
}