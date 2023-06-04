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
            var splitted = commandBody.Split(' ');

            string firstPath = String.Concat(splitted[0].Where(c => !Char.IsWhiteSpace(c)));
            string secondPath = String.Concat(splitted[1].Where(c => !Char.IsWhiteSpace(c)));

            if (commandBody == "")
            {
                throw new Exception("Enter command body");
            }
            else if ((firstPath == ".." && secondPath == "") || (secondPath == ".." && firstPath == ""))
            {
                throw new Exception("Enter desired path of the replacement");
            }
            else if (firstPath == ".." && secondPath == "..")
            {
                try
                {
                    replaceFiles(firstPath, secondPath);
                }
                catch (Exception e)
                {
                    throw new Exception("Path does look like the path");
                }
            }

            replaceFiles(firstPath, secondPath);

            static void replaceFiles(string fileA, string fileB)
            {

                FileInfo fileAinfo = new FileInfo(fileA);
                FileInfo fileBinfo = new FileInfo(fileB);

                File.Move(fileA, fileB.Replace("\\" + fileBinfo.Name, "") + "\\" + fileAinfo.Name, true);
                File.Move(fileB, fileA.Replace("\\" + fileAinfo.Name, "") + "\\" + fileBinfo.Name, true);
            }
            base.Execute(handler, commandBody);
        }
    }
}