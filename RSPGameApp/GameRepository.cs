using ClassLibrary.Data;
using ClassLibrary.Models;

namespace RSPGameApp
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public void SaveGame(string playerMove, string computerMove, string result)
        {
            int totalGames = _context.GameRecords.Count() + 1;
            int userWins = _context.GameRecords.Count(g => g.Result == "Win");
            int computerWins = _context.GameRecords.Count(g => g.Result == "Loss");

            var game = new GameRecord
            {
                PlayerMove = playerMove,
                ComputerMove = computerMove,
                Result = result,
                GameDate = DateTime.Now,
                UserWinRate = (double)(userWins + (result == "Win" ? 1 : 0)) / totalGames * 100,
                ComputerWinRate = (double)(computerWins + (result == "Loss" ? 1 : 0)) / totalGames * 100
            };

            _context.GameRecords.Add(game);
            _context.SaveChanges();
        }
        public List<GameRecord> GetGameHistory()
        {
            return _context.GameRecords.ToList();
        }


        public double GetWinRate()
        {
            int totalGames = _context.GameRecords.Count();
            int wins = _context.GameRecords.Count(g => g.Result == "Win");
            return totalGames > 0 ? (double)wins / totalGames * 100 : 0;
        }

        public (double UserWinRate, double ComputerWinRate) GetWinStats()
        {
            int totalGames = _context.GameRecords.Count();
            int userWins = _context.GameRecords.Count(g => g.Result == "Win");
            int computerWins = _context.GameRecords.Count(g => g.Result == "Loss");

            double userWinRate = totalGames > 0 ? (double)userWins / totalGames * 100 : 0;
            double computerWinRate = totalGames > 0 ? (double)computerWins / totalGames * 100 : 0;

            return (userWinRate, computerWinRate);
        }

    }        

}