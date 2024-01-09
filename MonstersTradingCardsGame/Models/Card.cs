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
        public string Name { get; set; }
        public double Damage { get; set; }

        // Any common properties or methods for all types of cards can be added here

    }
}



