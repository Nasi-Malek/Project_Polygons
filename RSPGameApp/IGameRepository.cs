using ClassLibrary.Models;

namespace RSPGameApp
{
    public interface IGameRepository
    {
        void SaveGame(string playerMove, string computerMove, string result);
        List<GameRecord> GetGameHistory();
        double GetWinRate(); 
        (double UserWinRate, double ComputerWinRate) GetWinStats();
    }

}
