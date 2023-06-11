using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class rename : TerminalRequest
    {
        public rename()
        {
            CommandName = "rename";
        }
        public override void Execute(CommandHandler handler, string commandBody = "")
        {

            Console.WriteLine("Введiть шлях до папки:"); string folderPath = Console.ReadLine();
            Console.WriteLine("Введiть iм'я файлу який хочете переназвати:");
            string oldFileName = Console.ReadLine();
            Console.WriteLine("Введiть нове iм'я файлу:"); string newFileName = Console.ReadLine();
            string filePath = Path.Combine(folderPath, oldFileName);
            string newFilePath = Path.Combine(folderPath, newFileName);
            if (File.Exists(filePath))
            {
                File.Move(filePath, newFilePath); Console.WriteLine($"Файл {oldFileName} переназвано в {newFileName}.");
            }
            else
            {
                Console.WriteLine($"Файл {oldFileName} не знайдено.");
            }
            Console.ReadLine();
        }
    }
}
