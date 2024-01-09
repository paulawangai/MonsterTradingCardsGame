// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/MonsterCard.cs

namespace MonsterTradingCardsGame.Models
{
    // Represents a monster card, which is a specific type of card in the game
    public class MonsterCard : Card
    {
        // Additional properties specific to monster cards
        public string MonsterType { get; set; }

        // Special abilities based on monster type
        public string SpecialAbility { get; set; }

        // Constructor for creating a MonsterCard with specific attributes
        public MonsterCard(string name, double damage, string monsterType, string specialAbility)
        {
            // Set common properties from the base class
            Name = name;
            Damage = damage;

            // Set properties specific to monster cards
            MonsterType = monsterType;
            SpecialAbility = specialAbility;
        }
    }
}
