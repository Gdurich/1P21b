using Microsoft.Win32;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class Ccleaner : TerminalRequest
    {
        public string Name { get; } = "ccleaner";

        public void Execute(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: ccleaner <directory>");
                return;
            }

            string directory = args[0];

            if (!Directory.Exists(directory))
            {
                Console.WriteLine("Directory does not exist.");
                return;
            }

            string[] fileTypes = GetRegisteredFileTypes();

            DeleteFilesByExtensions(directory, fileTypes);

            Console.WriteLine("Cleaning completed.");
        }

        private string[] GetRegisteredFileTypes()
        {
            RegistryKey classesRootKey = Registry.ClassesRoot;

            string[] subKeys = classesRootKey.GetSubKeyNames();

            string[] fileTypes = subKeys
                .Where(key => key.StartsWith("."))
                .ToArray();

            classesRootKey.Close();

            return fileTypes;
        }

        private void DeleteFilesByExtensions(string directory, string[] fileTypes)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);

            foreach (FileInfo file in directoryInfo.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                string fileExtension = Path.GetExtension(file.Name);

                if (!fileTypes.Contains(fileExtension))
                {
                    file.Delete();
                    Console.WriteLine($"Deleted file: {file.FullName}");
                }
            }
        }
    }
}
