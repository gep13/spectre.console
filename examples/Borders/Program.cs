using Spectre.Console;
using Spectre.Console.Rendering;

namespace BordersExample
{
    public static class Program
    {
        public static void Main()
        {
            // Render panel borders
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[white bold underline]PANEL BORDERS[/]");
            AnsiConsole.WriteLine();
            RenderPanelBorders();

            // Render table borders
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[white bold underline]TABLE BORDERS[/]");
            AnsiConsole.WriteLine();
            RenderTableBorders();
        }

        private static void RenderPanelBorders()
        {
            static IRenderable CreatePanel(string name, BoxBorder border)
            {
                return new Panel($"This is a panel with\nthe [yellow]{name}[/] border.")
                    .SetHeader($" {name} ", Style.Parse("blue"), Justify.Center)
                    .SetBorderStyle(Style.Parse("grey"))
                    .SetBorder(border);
            }

            var items = new[]
            {
                CreatePanel("Ascii", BoxBorder.Ascii),
                CreatePanel("Square", BoxBorder.Square),
                CreatePanel("Rounded", BoxBorder.Rounded),
                CreatePanel("Heavy", BoxBorder.Heavy),
                CreatePanel("Double", BoxBorder.Double),
                CreatePanel("None", BoxBorder.None),
            };

            AnsiConsole.Render(
                new Padder(
                    new Columns(items).PadRight(2),
                    new Padding(2,0,0,0)));
        }

        private static void RenderTableBorders()
        {
            static IRenderable CreateTable(string name, TableBorder border)
            {
                var table = new Table().SetBorder(border);
                table.AddColumn("[yellow]Header 1[/]");
                table.AddColumn("[yellow]Header 2[/]", col => col.RightAligned());
                table.AddRow("Cell", "Cell");
                table.AddRow("Cell", "Cell");

                return new Panel(table)
                    .SetHeader($" {name} ", Style.Parse("blue"), Justify.Center)
                    .SetBorderStyle(Style.Parse("grey"))
                    .NoBorder();
            }

            var items = new[]
            {
                CreateTable("Ascii", TableBorder.Ascii),
                CreateTable("Ascii2", TableBorder.Ascii2),
                CreateTable("AsciiDoubleHead", TableBorder.AsciiDoubleHead),
                CreateTable("Horizontal", TableBorder.Horizontal),
                CreateTable("Simple", TableBorder.Simple),
                CreateTable("SimpleHeavy", TableBorder.SimpleHeavy),
                CreateTable("Minimal", TableBorder.Minimal),
                CreateTable("MinimalHeavyHead", TableBorder.MinimalHeavyHead),
                CreateTable("MinimalDoubleHead", TableBorder.MinimalDoubleHead),
                CreateTable("Square", TableBorder.Square),
                CreateTable("Rounded", TableBorder.Rounded),
                CreateTable("Heavy", TableBorder.Heavy),
                CreateTable("HeavyEdge", TableBorder.HeavyEdge),
                CreateTable("HeavyHead", TableBorder.HeavyHead),
                CreateTable("Double", TableBorder.Double),
                CreateTable("DoubleEdge", TableBorder.DoubleEdge),
                CreateTable("Markdown", TableBorder.Markdown),
            };

            AnsiConsole.Render(new Columns(items).Collapse());
        }
    }
}
