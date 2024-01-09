// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/TradingDeal.cs

namespace MonsterTradingCardsGame.Models
{
    /// <summary>
    /// Represents a trading deal, including a unique identifier, the card to trade, type requirement, and minimum damage.
    /// </summary>
    public class TradingDeal
    {
        public Guid Id { get; set; }
        public Guid CardToTrade { get; set; }
        public string Type { get; set; }
        public double MinimumDamage { get; set; }
    }
}
