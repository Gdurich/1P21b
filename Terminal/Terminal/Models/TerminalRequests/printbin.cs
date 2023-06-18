using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Handlers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    internal class printbin : TerminalRequest
    {
        public printbin()
        {
            CommandName = "printbin";
        }
        public override void Execute(CommandHandler handler, string commandBody = "")
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть шлях до файлу: ");
            string filePath = Console.ReadLine();

            try
            {
                byte[] fileBytes = File.ReadAllBytes(filePath);
                string binaryString = ConvertToBinary(fileBytes);
                Console.WriteLine("Бінарний код файлу:");
                Console.WriteLine(binaryString);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Помилка при читанні файлу: {e.Message}");
            }

            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        static string ConvertToBinary(byte[] bytes)
        {
            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (byte b in bytes)
            {
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            return binaryStringBuilder.ToString();
        }

    }
}
