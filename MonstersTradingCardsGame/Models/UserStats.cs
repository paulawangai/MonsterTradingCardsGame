// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/UserStats.cs

namespace MonsterTradingCardsGame.Models
{
    /// <summary>
    /// Represents statistics for a user, including Elo rating, wins, and losses.
    /// </summary>
    public class UserStats
    {
        public string Name { get; set; }
        public int Elo { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
