// MonstersTradingCardsGame/MonsterTradingCardsGame/Models/UserCredentials.cs

using System.ComponentModel.DataAnnotations;

namespace MonsterTradingCardsGame.Models
{
    /// <summary>
    /// Represents the credentials (username and password) for user registration and login.
    /// </summary>
    public class UserCredentials
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
