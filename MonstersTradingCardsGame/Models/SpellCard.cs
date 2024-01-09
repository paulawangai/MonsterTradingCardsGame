// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/SpellCard.cs

namespace MonsterTradingCardsGame.Models
{
    // Represents a spell card, which is a specific type of card in the game
    public class SpellCard : Card
    {
        // Element type of the spell card (e.g., fire, water, normal)
        public string Element { get; set; }

        // Represents the effectiveness of the spell card against other elements
        public double CalculateEffectiveness(string targetElement)
        {
            // Define the effectiveness mapping
            // You can adjust these values based on your game's balance
            double effectiveness = 1.0; // Default: no effect

            // Check the effectiveness based on the specified rules
            switch (Element.ToLower())
            {
                case "water":
                    effectiveness = targetElement.ToLower() == "fire" ? 2.0 :  // Water is effective against fire
                                    targetElement.ToLower() == "normal" ? 0.5 : 1.0; // Water is not effective against normal
                    break;
                case "fire":
                    effectiveness = targetElement.ToLower() == "normal" ? 0.5 : 1.0; // Fire is not effective against normal
                    break;
                case "normal":
                    effectiveness = targetElement.ToLower() == "water" ? 2.0 : 1.0; // Normal is effective against water
                    break;
                    // Add more cases for additional elements if needed
            }

            return effectiveness;
        }

        // Additional properties specific to spell cards can be added here
    }
}
