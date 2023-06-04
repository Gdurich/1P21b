using Terminal.Handlers;
using Terminal.Models.TerminalRequests;

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
        .AddCommandObject(new printbin());
    commandHandler
        .AddCommandObject(new CD_TerminalRequest());
    commandHandler
        .AddCommandObject(new Append());
    commandHandler
        .AddCommandObject(new TREE_TerminalRequest());
    commandHandler
        .AddCommandObject(new REPLACE_TerminalRequest());
    commandHandler
        .AddCommandObject(new REWRITE_TerminalRequest());
}