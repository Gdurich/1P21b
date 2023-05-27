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
                string path = CommandHandler.CurrentDirectoryPath;
                int indentSize = 4;
                printTree(path, indentSize, "");

            static void printTree(string path, int indentSize, string indent)
            {
                DirectoryInfo directory = new DirectoryInfo(path);

                Console.WriteLine(indent + directory.Name);

                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(indent + new string(' ', indentSize) + file.Name);
                }

                DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    printTree(subDirectory.FullName, indentSize, indent + new string(' ', indentSize));
                }
            }
            base.Execute(handler, commandBody);
        }
    }
}