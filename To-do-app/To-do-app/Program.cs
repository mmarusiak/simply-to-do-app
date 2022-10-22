using System;
using Spectre.Console;

namespace To_do_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var table = new Table();
            table.AddColumn("[blue]Number[/]");
            table.AddColumn("[orange1]Operation[/]");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            table.AddRow("1.", "Test");
            AnsiConsole.Write(table);
        }
    }
}