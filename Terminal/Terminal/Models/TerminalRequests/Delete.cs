using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class Delete : TerminalRequest
    {
        public Delete() 
        { 
            CommandName = "delete";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            Console.WriteLine("Введіть назву файлу або папки, яку потрібно видалити:");
            string name = Console.ReadLine();

            if (File.Exists(name))
            {
                File.SetAttributes(name, FileAttributes.Normal);
                File.Delete(name);
                Console.WriteLine($"Файл {name} успішно видалено.");
            }
            else if (Directory.Exists(name))
            {
                if (Directory.GetFileSystemEntries(name).Length > 0)
                {
                    Console.WriteLine($"Папка {name} не може бути видалена, оскільки вона містить інші файли або папки.");
                }
                else
                {
                    Directory.Delete(name);
                    Console.WriteLine($"Папку {name} успішно видалено.");
                }
            }
            else
            {
                Console.WriteLine($"Файл або папку '{name}' не знайдено.");
            }
        }
    }
}


