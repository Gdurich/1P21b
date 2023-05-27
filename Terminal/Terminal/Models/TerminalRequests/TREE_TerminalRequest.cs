using System.Linq.Expressions;
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
                    try 
                    {
                        Console.WriteLine(indent + "├" + new string('─', indentSize) + file.Name);
                    }
                    catch (UnauthorizedAccessException)
                    {

                    }
                    }

                    DirectoryInfo[] subDirectories = directory.GetDirectories();
                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    try 
                    {
                        printTree(subDirectory.FullName, indentSize, indent + new string(' ', indentSize));
                    }
                    catch (UnauthorizedAccessException)
                    {

                    }
                    }
                }
            base.Execute(handler, commandBody);
        }
    }
}