// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/Card.cs

using System;

namespace MonsterTradingCardsGame.Models
{
    /// <summary>
    /// Represents a base class for all cards, including unique identifier, name, and damage.
    /// </summary>

    // Base class for all cards in the Monster Trading Cards Game
    public abstract class Card
    {
        // Unique identifier for each card
        public Guid Id { get; set; }

        // Name of the card
        public string Name { get; set; }

        // Damage value of the card
        public double Damage { get; set; }
    }
}



