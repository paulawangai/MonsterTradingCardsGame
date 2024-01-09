// MonstersTradingCardsGame/MonsterTradingCardsGame/Services/BattleService.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    double damageA = CalculateDamage(playerACard, playerBCard);
                    double damageB = CalculateDamage(playerBCard, playerACard);

                    // Implement your monster fight logic here
                    // Consider special abilities and elemental interactions

                    // Update player decks accordingly
                    UpdatePlayerDecks(playerACard, playerBCard, damageA, damageB, playerADeck, playerBDeck);
                }
                else if (playerACard is SpellCard || playerBCard is SpellCard)
                {
                    // Handle spell fights
                    double damageA = CalculateDamage(playerACard, playerBCard);
                    double damageB = CalculateDamage(playerBCard, playerACard);

                    // Implement your spell fight logic here

                    // Consider elemental interactions and update player decks accordingly
                    UpdatePlayerDecks(playerACard, playerBCard, damageA, damageB, playerADeck, playerBDeck);
                }
                else
                {
                    // Handle mixed fights (one spell card, one monster card)
                    MonsterCard monsterCard;
                    SpellCard spellCard;

                    if (playerACard is MonsterCard)
                    {
                        monsterCard = (MonsterCard)playerACard;
                        spellCard = (SpellCard)playerBCard;
                    }
                    else
                    {
                        monsterCard = (MonsterCard)playerBCard;
                        spellCard = (SpellCard)playerACard;
                    }
                    // Implement your mixed fight logic here

                    // Consider elemental interactions and special abilities
                    ApplyMonsterSpecialAbilities(monsterCard, spellCard);

                    double damageA = CalculateDamage(playerACard, playerBCard);
                    double damageB = CalculateDamage(playerBCard, playerACard);

                    // Update player decks accordingly
                    UpdatePlayerDecks(playerACard, playerBCard, damageA, damageB, playerADeck, playerBDeck);
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

        // Calculate damage for a fight between two cards
        private double CalculateDamage(Card attacker, Card defender)
        {
            double baseDamage = attacker.Damage;

            // Check if it's a spell card fight
            if (attacker is SpellCard && defender is SpellCard)
            {
                SpellCard spellAttacker = (SpellCard)attacker;
                SpellCard spellDefender = (SpellCard)defender;

                // Implement spell card effectiveness logic
                if (IsEffective(spellAttacker.Element, spellDefender.Element))
                {
                    return baseDamage * 2; // Damage is doubled
                }
                else if (IsEffective(spellDefender.Element, spellAttacker.Element))
                {
                    return baseDamage / 2; // Damage is halved
                }
                else
                {
                    return baseDamage; // No effect
                }
            }

            return baseDamage; // Default for other cases
        }

        // Check if one element type is effective against another
        private bool IsEffective(string attackingElement, string defendingElement)
        {
            if ((attackingElement == "water" && defendingElement == "fire") ||
                (attackingElement == "fire" && defendingElement == "normal") ||
                (attackingElement == "normal" && defendingElement == "water"))
            {
                return true;
            }

            return false;
        }

        // Apply special abilities for monster cards during mixed fights
        private void ApplyMonsterSpecialAbilities(MonsterCard monsterCard, SpellCard spellCard)
        {
            if (monsterCard.MonsterType == "Goblin" && spellCard is DragonCard)
            {
                // Goblins are too afraid of Dragons to attack
                monsterCard.Damage = 0.0;
            }
            else if (monsterCard.MonsterType == "Wizard" && spellCard is OrkCard)
            {
                // Wizards can control Orks, so they are not able to damage them
                monsterCard.Damage = 0.0;
            }
            else if (monsterCard.MonsterType == "Knight" && spellCard.Element == "water")
            {
                // The armor of Knights is so heavy that WaterSpells make them drown instantly
                monsterCard.Damage = 0.0;
            }
            else if (monsterCard.MonsterType == "Kraken" && spellCard is SpellCard)
            {
                // The Kraken is immune against spells
                monsterCard.Damage = 0.0;
            }
            else if (monsterCard.MonsterType == "FireElf" && spellCard is DragonCard)
            {
                // The FireElves know Dragons since they were little and can evade their attacks
                monsterCard.Damage = 0.0;
            }
        }

        // Update player decks based on the results of a fight
        private void UpdatePlayerDecks(Card cardA, Card cardB, double damageA, double damageB,
            List<Card> playerADeck, List<Card> playerBDeck)
        {
            if (damageA > damageB)
            {
                playerBDeck.Remove(cardB);
                playerADeck.Add(cardB);
            }
            else if (damageB > damageA)
            {
                playerADeck.Remove(cardA);
                playerBDeck.Add(cardA);
            }
            else
            {
                // Draw, no action needed
            }
        }

        // Generate a battle log based on the results of the battle
        private string GenerateBattleLog(int roundCount, bool isDraw)
        {
            // Implement your logic to generate a detailed battle log here
            // Include information about each round, card matchups, and the winner
            // You can use StringBuilder to construct the log efficiently

            StringBuilder battleLog = new StringBuilder();
            battleLog.AppendLine($"Battle Log - Rounds: {roundCount}");
            battleLog.AppendLine($"Draw: {isDraw}");

            // Add more details to the battle log as needed

            return battleLog.ToString();
        }
    }
}
