using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using To_do_app.Services;
using To_do_app.ValueObjects;

namespace To_do_app
{
    class Program
    {
        static void Main(string[] args)
        {
            ActivityServices activityServices = new ActivityServices();
            
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

            switch (operation)
            {
                // show list
                case 0:
                    AnsiConsole.Write(GetList(activityServices.Activities));
                    break;
                // add activity
                case 1:
                    string newActivityDescription = AnsiConsole.Ask<string>("Provide your [blue]activity description:[/]");
                    activityServices.AddActivity(newActivityDescription);
                    AnsiConsole.Write(GetList(activityServices.Activities));
                    break;
                // remove activity
                case 2:
                    break;
                // mark as completed
                case 3:
                    break;
                // mark as uncompleted
                case 4:
                    break;
                // clear list
                case 5:
                    break;
                // exit
                case 6:
                    break;
            }
            
        }
        
        private static Table GetList(IEnumerable<Activity> activities)
        {
            var table = new Table();
            table.AddColumn(new TableColumn("Action").Centered());
            table.AddColumn(new TableColumn("State").Centered());
            table.Border = TableBorder.Minimal;
            
            foreach (var activity in activities)
            {
                table.AddRow(activity.ActionDescription, (activity.IsDone ? "[green]Completed[/]" : "[red]Uncompleted[/]"));
            }

            return table;
        }
    }
}