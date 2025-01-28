using Spectre.Console;
using System;
using RSPGameApp;

namespace RSPGameApp
{
    public class GameHandler
    {
        private readonly IGameRepository _repository;

  
        public GameHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public void PlayGame()
        {
            Console.Clear();
                var playerMove = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[blue]Choose your move:[/]")
                    .AddChoices("Rock", "Scissors", "Paper"));

            string computerMove = GetComputerMove();
            string result = DetermineResult(playerMove, computerMove);

            AnsiConsole.Markup($"\n[green]You chose:[/] [bold]{playerMove}[/]");
            AnsiConsole.Markup($"\n[red]Computer chose:[/] [bold]{computerMove}[/]");
            AnsiConsole.Markup($"\n[blue]Result:[/] [bold]{result}[/]\n");

            _repository.SaveGame(playerMove, computerMove, result);
            AnsiConsole.Markup("[green]Game saved successfully![/]\n");
            AnsiConsole.Markup("[green]Press any key to return...[/]");
            Console.ReadKey();
        }

        public void ShowGameHistory()
        {
            Console.Clear();
            var history = _repository.GetGameHistory();

            if (history == null || history.Count == 0)
            {
                AnsiConsole.Markup("[red]No games played yet.[/]");
            }
            else
            {
                var table = new Table();
                table.AddColumn("Date");
                table.AddColumn("Player Move");
                table.AddColumn("Computer Move");
                table.AddColumn("Result")
                .AddColumn("User Win Rate")
                .AddColumn("Computer Win Rate");

                foreach (var game in history)
                {
                    table.AddRow(
                        game.GameDate.ToString("g"),
                        game.PlayerMove,
                        game.ComputerMove,
                        game.Result,
                        $"{game.UserWinRate:F2}%",
                        $"{game.ComputerWinRate:F2}%");
                }

                AnsiConsole.Write(table);
            }

            AnsiConsole.Markup("[green]Press any key to return...[/]");
            Console.ReadKey();
        }

        public void ShowWinRate()
        {
            Console.Clear();
            var stats = _repository.GetWinStats();
            double userWinRate = stats.UserWinRate;
            double computerWinRate = stats.ComputerWinRate;

            AnsiConsole.Markup($"\n[blue]Your Win Rate:[/] [bold]{userWinRate:F2}%[/]");
            AnsiConsole.Markup($"\n[red]Computer Win Rate:[/] [bold]{computerWinRate:F2}%[/]");
            AnsiConsole.Markup("\n[green]Press any key to return...[/]");
            Console.ReadKey();

        }

        private string GetComputerMove()
        {
            var moves = new[] { "Rock", "Scissors", "Paper" };
            Random random = new Random();
            return moves[random.Next(moves.Length)];
        }

        private string DetermineResult(string playerMove, string computerMove)
        {
            if (playerMove == computerMove) return "Draw";

            return (playerMove, computerMove) switch
            {
                ("Rock", "Scissors") => "Win",
                ("Scissors", "Paper") => "Win",
                ("Paper", "Rock") => "Win",
                _ => "Loss"
            };
        }
    }
}