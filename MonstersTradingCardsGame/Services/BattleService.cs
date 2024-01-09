// MonstersTradingCardsGame/MonsterTradingCardsGame/Services/BattleService.cs

using System;
using System.Collections.Generic;
using System.Linq;
using MonsterTradingCardsGame.Models;

namespace MonsterTradingCardsGame.Services
{
    // Service responsible for handling battles between players
    public class BattleService
    {
        // Perform a battle between two players
        public string PerformBattle(List<Card> playerACards, List<Card> playerBCards)
        {
            // Initialization and setup for battle
            int roundCount = 0;
            bool isDraw = false;
            List<Card> playerADeck = new List<Card>(playerACards);
            List<Card> playerBDeck = new List<Card>(playerBCards);

            // Main battle loop
            while (roundCount < 100) // Limit rounds to 100 to prevent endless loops
            {
                roundCount++;

                // Randomly choose one card from each player's deck
                Card playerACard = playerADeck.OrderBy(card => Guid.NewGuid()).FirstOrDefault();
                Card playerBCard = playerBDeck.OrderBy(card => Guid.NewGuid()).FirstOrDefault();

                // Check if it's a pure monster fight (no spell cards involved)
                if (playerACard is MonsterCard && playerBCard is MonsterCard)
                {
                    MonsterCard monsterCardA = (MonsterCard)playerACard;
                    MonsterCard monsterCardB = (MonsterCard)playerBCard;

                    // Handle monster fights
                    // Implement your monster fight logic here
                    // Consider special abilities and elemental interactions
                    // Update player decks accordingly
                }
                else if (playerACard is SpellCard || playerBCard is SpellCard)
                {
                    // Handle spell fights
                    // Implement your spell fight logic here
                    // Consider elemental interactions and update player decks accordingly
                }
                else
                {
                    // Handle mixed fights (one spell card, one monster card)
                    // Implement your mixed fight logic here
                    // Consider elemental interactions and special abilities
                    // Update player decks accordingly
                }

                // Check for a draw
                if (isDraw)
                {
                    // No action taken for a draw
                }

                // Check if one player has no cards left
                if (playerADeck.Count == 0 || playerBDeck.Count == 0)
                {
                    // Battle completed
                    break;
                }
            }

            // Generate and return battle log
            string battleLog = GenerateBattleLog(roundCount, isDraw);
            return battleLog;
        }

        // Generate a battle log based on the results of the battle
        private string GenerateBattleLog(int roundCount, bool isDraw)
        {
            // Implement your logic to generate a detailed battle log here
            // Include information about each round, card matchups, and the winner
            // You can use StringBuilder to construct the log efficiently

            return "Battle Log"; // Replace with the actual battle log
        }
    }
}
