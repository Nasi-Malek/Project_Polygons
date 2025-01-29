using Spectre.Console;


namespace CalculatorApp.Handlers
{
    public class UpdateHandler
    {
        private readonly ICalculatorRepository _repository;

        public UpdateHandler(ICalculatorRepository repository)
        {
            _repository = repository;
        }

        public void UpdateCalculation()
        {
            try
            {
                Console.Clear();
                AnsiConsole.Markup("[blue]Update Calculation:[/]\n");

                int id = GetValidId("Enter the ID of the calculation to update: ");
                var calculation = _repository.GetCalculationById(id);

                if (calculation is null)
                {
                    AnsiConsole.Markup("[red]Calculation not found. Please check the ID and try again.[/]");
                    Console.ReadKey();
                    return;
                }

                AnsiConsole.Markup("[green]Current Calculation Details:[/]\n");
                AnsiConsole.Markup($"[yellow]{calculation.Num1} {calculation.Operation} {calculation.Num2} = {calculation.Result}[/]\n");

                try
                {
                    double newNum1 = GetValidInput("Enter the new first number: ");
                    double newNum2 = GetValidInput("Enter the new second number: ");
                    string operation = calculation.Operation;

                    double newResult = CalculateResult(newNum1, newNum2, operation);

                    if (_repository.UpdateCalculation(id, newNum1, newNum2, newResult))
                    {
                        AnsiConsole.Markup("[green]Calculation updated successfully![/]");
                    }
                    else
                    {
                        AnsiConsole.Markup("[red]Failed to update calculation. Please try again.[/]");
                    }
                }
                catch (Exception ex)
                {
                    AnsiConsole.Markup($"[red]An error occurred: {ex.Message}[/]");
                }
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup($"[red]An error occurred: {ex.Message}[/]");
            }
        }

        private double CalculateResult(double num1, double num2, string operation)
        {
            return operation switch
            {
                "+" => num1 + num2,
                "-" => num1 - num2,
                "*" => num1 * num2,
                "/" => num2 != 0 ? num1 / num2 : throw new DivideByZeroException("Cannot divide by zero."),
                "%" => num2 != 0 ? num1 % num2 : throw new DivideByZeroException("Cannot perform modulus with zero."),
                _ => throw new InvalidOperationException("Invalid operation.")
            };
        }

        private double GetValidInput(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<double>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid number.[/]")
                    .Validate(value => true));
        }

        private int GetValidId(string prompt)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>($"[yellow]{prompt}[/]")
                    .ValidationErrorMessage("[red]Please enter a valid positive integer.[/]")
                    .Validate(value => value > 0
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]ID must be positive.[/]")));
        }
    }

}
public class CalculationRecord
{
    public int Id { get; set; }
    public double? Num1 { get; set; }
    public double? Num2 { get; set; }
    public string Operation { get; set; } = string.Empty;
    public double Result { get; set; }
    public DateTime Date { get; set; }
    public bool IsDeleted { get; set; } // Added soft delete support
}