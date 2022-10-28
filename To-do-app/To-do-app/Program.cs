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
                "[green]See to do list[/]", "Add activity", "Remove activity", "Mark activity as completed",
                "Mark activity as uncompleted", "Clear list",
                "[red]Exit[/]"
            };

            int operation;
            do
            {
                operation = Array.IndexOf(operations, AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select operation using [blue]<^>[/] and [green]enter[/]")
                        .PageSize(10)
                        .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                        .AddChoices(operations)));

                HashSet <Activity> activities = activityServices.Activities.ToHashSet();
                switch (operation)
                {
                    
                    // show list
                    case 0:
                        ShowList(activityServices.Activities);
                        break;
                    // add activity
                    case 1:
                        string newActivityDescription =
                            AnsiConsole.Ask<string>("Provide your [blue]activity description:[/]");
                        activityServices.AddActivity(newActivityDescription);
                        ShowList(activityServices.Activities);
                        break;
                    // remove activity
                    case 2:
                        if (activities.Count > 0)
                        {
                            foreach (var activity in SelectActivity(activityServices.Activities))
                            {
                                activityServices.RemoveActivity(activity);
                            }

                            ShowList(activityServices.Activities);
                        }
                        else
                            AnsiConsole.WriteLine("List is empty!");

                        break;
                    // mark as completed
                    case 3:
                        if (activities.Count > 0)
                        {
                            foreach (var activity in SelectActivity(activityServices.Activities))
                            {
                                activities.Remove(activity);
                                activities.Add(new Activity(activity.ActionDescription, true));
                            }

                            activityServices.SetList(activities);
                            ShowList(activityServices.Activities);
                        }
                        else
                            AnsiConsole.WriteLine("List is empty!");

                        break;
                    // mark as uncompleted
                    case 4:
                        if (activities.Count > 0)
                        {
                            foreach (var activity in SelectActivity(activityServices.Activities))
                            {
                                activities.Remove(activity);
                                activities.Add(new Activity(activity.ActionDescription, false));
                            }

                            activityServices.SetList(activities);
                            ShowList(activityServices.Activities);
                        }
                        else 
                            AnsiConsole.WriteLine("List is empty!");
                        break;
                    // clear list
                    case 5:
                        if (AnsiConsole.Confirm("Are you sure, you want to [orange1]clear[/] all list?"))
                        {
                            activityServices.ClearList();
                        }
                        break;
                    // exit
                    case 6:
                        break;
                }
            } while (operation != 6);

        }

        private static Activity[] SelectActivity(IEnumerable<Activity> activities)
        {
            List<Activity> result = new List<Activity>();
            List<string> multipleSelection = new List<string>();
            foreach (var activity in activities)
            {
                multipleSelection.Add(activity);
            }
            var actToRemove = AnsiConsole.Prompt(
                new MultiSelectionPrompt<string>()
                    .Title("What activity do you want to remove?")
                    .NotRequired() // Not required to have a favorite fruit
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more activities)[/]")
                    .InstructionsText(
                        "[grey](Press [blue]<space>[/] to toggle an activity, " + 
                        "[green]<enter>[/] to accept)[/]")
                    .AddChoices(multipleSelection.ToArray()));
            foreach (var activityDes in actToRemove)
            {
                result.Add(activities.ToArray()[Array.IndexOf(multipleSelection.ToArray(), activityDes)]);
            }

            return result.ToArray();
        }
        
        private static void ShowList(IEnumerable<Activity> activities)
        {
            AnsiConsole.Write(GetList(activities));
            AnsiConsole.Ask("[orange1]Click enter to continue[/]", "");
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