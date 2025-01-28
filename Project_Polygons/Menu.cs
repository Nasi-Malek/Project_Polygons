using CalculatorApp;
using RSPGameApp;
using ShapeApp;
using Spectre.Console;



namespace Project_Polygons
{
    public class Menu
        {
            private readonly ShapesController _shapesController;
            private readonly CalculatorHandler _calculatorHandler;
            private readonly GameHandler _gameHandler;


            public Menu(ShapesController shapesController, CalculatorHandler calculatorHandler, GameHandler gameHandler)
            {
                _shapesController = shapesController;
                _calculatorHandler = calculatorHandler;
                _gameHandler = gameHandler;
            }

            public void ShowMainMenu()
            {
                bool exit = false;

                while (!exit)
                {
                    
                    Console.Clear();
                    AnsiConsole.Write(
                        new FigletText("Polygons Project")
                            .Centered()
                            .Color(Color.Red));

                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[blue]Choose a Project:[/]")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                            "Shapes", "Calculator", "Rock, Scissors, Paper", "Exit"
                            }));

                    switch (choice)
                    {
                        case "Shapes":
                            CallShapesProject();
                            break;

                        case "Calculator":
                            CallCalculatorProject();
                            break;

                        case "Rock, Scissors, Paper":
                            CallGameProject();
                            break;

                        case "Exit":
                            AnsiConsole.Markup("[bold red]Exiting the app. Goodbye![/]");
                            exit = true;
                            break;
                    }
                }
            }

            private void CallShapesProject()
            {
                Console.Clear();
                AnsiConsole.Markup("[green]You selected Shapes![/]");
                Console.WriteLine();

                _shapesController.ShowShapesMenu();

                AnsiConsole.Markup("[green]Returning to the main menu...[/]");
                Console.ReadKey();
            }

            private void CallCalculatorProject()
            {
                Console.Clear();
                AnsiConsole.Markup("[green]You selected Calculator![/]");
                Console.WriteLine();

                _calculatorHandler.ShowCalculatorMenu();

                AnsiConsole.Markup("[green]Returning to the main menu...[/]");
                Console.ReadKey();
            }

            private void CallGameProject()
            {

                while (true)
                {
                    Console.Clear();
                    AnsiConsole.Markup("[blue]Rock, Scissors, Paper Menu:[/]");
                    Console.WriteLine();

                    var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[blue]Choose an option:[/]")
                            .PageSize(10)
                            .AddChoices(new[]
                            {
                            "Play Game", "View Game History", "View Win Rate", "Back to Main Menu"
                            }));

                    switch (choice)
                    {
                        case "Play Game":
                            _gameHandler.PlayGame();
                            break;

                        case "View Game History":
                            _gameHandler.ShowGameHistory();
                            break;

                        case "View Win Rate":
                            _gameHandler.ShowWinRate();
                            break;

                        case "Back to Main Menu":
                            return;
                    }
                }
            }

        }
    }
