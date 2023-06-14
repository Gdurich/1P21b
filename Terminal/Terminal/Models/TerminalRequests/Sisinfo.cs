using System;
using System.Diagnostics;
using System.IO;
using Terminal.Handlers;
using Terminal.Helpers;
using Terminal.Models.TerminalRequests.Base;

namespace Terminal.Models.TerminalRequests
{
    public class Sisinfo : TerminalRequest
    {
        public Sisinfo()
        {
            CommandName = "sisinfo";
        }

        public override void Execute(string[] arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "SYSTEMINFO",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                Process process = new Process();
                process.StartInfo = startInfo;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();

                Console.WriteLine(output);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while executing the command: {ex.Message}");
            }
        }
    }
}
