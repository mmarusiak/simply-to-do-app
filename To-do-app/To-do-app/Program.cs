using System;
using Spectre.Console;

namespace To_do_app
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] operations = 
            {
                "[royalblue1]See to do list[/]", "Add activity", "Remove activity", "Mark activity as completed",
                "Mark activity as uncompleted", "Clear list",
                "[red]Exit[/]"
            };
            
            var operation = Array.IndexOf(operations, AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[orange1]Select operation using [/] [blue]<^>[/] and [green]enter[/]")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                    .AddChoices(operations)));

            // Echo the fruit back to the terminal
            AnsiConsole.Write($"Operation {operation}");
        }
    }
}