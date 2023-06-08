using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests.Base
{
    public class ZipCommand : TerminalRequest
    {
        public ZipCommand()
        {
            CommandName = "zip";
        }

        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            string directoryPath = commandBody.Trim();

            if (string.IsNullOrEmpty(directoryPath))
            {
                Console.WriteLine("Помилка: Не вказано шлях до папки.");
                return;
            }

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Помилка: Папка '{directoryPath}' не існує.");
                return;
            }

            string zipFileName = $"{directoryPath}.zip";

            try
            {
                System.IO.Compression.ZipFile.CreateFromDirectory(directoryPath, zipFileName);
                Console.WriteLine($"Успішно створено архів: {zipFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: Не вдалося створити архів - {ex.Message}");
            }
        }
    }
}
