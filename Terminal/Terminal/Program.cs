using Terminal.Handlers;
using Terminal.Models.TerminalRequests;
using Terminal.Models.TerminalRequests.Base;

CommandHandler commandHandler = new CommandHandler(); ;
Init();

while (true)
{
    Console.Write($"_{CommandHandler.CurrentDirectoryPath}>");
    string commandString = Console.ReadLine();
    if(commandString != null && commandString != "")
        commandHandler.ExecuteCommand(commandString);
}




void Init()
{
    commandHandler
        .AddCommandObject(new CD_TerminalRequest());
    commandHandler
        .AddCommandObject(new ZipCommand());
}