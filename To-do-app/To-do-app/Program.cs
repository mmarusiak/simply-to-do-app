using System;
using Spectre.Console;

namespace To_do_app
{
    class Program
    {
        static void Main(string[] args)
        {
            var menuTable = new Table();
            var toDoActivitiesTable = new Table();
            var doneActivitiesTable = new Table();
            var table = new Table();
            menuTable.AddColumn("[blue]Number[/]");
            menuTable.AddColumn("[orange1]Operation[/]");
            menuTable.AddRow("1.", "Add activity");
            menuTable.AddRow("2.", "Remove activity");
            menuTable.AddRow("3.", "Mark as done activity");
            menuTable.AddRow("4.", "Mark as undone activity");
            menuTable.AddRow("5.", "Exit");

            table.AddColumn("Simply to do app");
            table.AddColumn("");
            table.AddColumn("");
            table.AddRow(menuTable, toDoActivitiesTable, doneActivitiesTable);
            AnsiConsole.Write(table);
        }
    }
}