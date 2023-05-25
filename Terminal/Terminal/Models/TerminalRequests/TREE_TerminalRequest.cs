using Terminal.Handlers;
using Terminal.Helpers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class TREE_TerminalRequest : TerminalRequest
    {
        public TREE_TerminalRequest() {
            CommandName = "tree";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            base.Execute(handler, commandBody);
        }
    }
}