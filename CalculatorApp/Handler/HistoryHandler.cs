using Spectre.Console;


namespace CalculatorApp.Handler
{
    public class HistoryHandler
    {
        private readonly ICalculatorRepository _repository;

        public HistoryHandler(ICalculatorRepository repository)
        {
            _repository = repository;
        }

        public void ShowHistory()
        {
            Console.Clear();
            AnsiConsole.Markup("[blue]Displaying Calculation History:[/]\n");
            _repository.DisplayAllCalculations();
            AnsiConsole.Markup("[green]Press any key to return to the menu...[/]");
            Console.ReadKey();
        }
    }
}
