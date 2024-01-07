using System.ComponentModel.DataAnnotations;

namespace FirstBlazorApp.DTOs
{
    public class HighScoreDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string PlayerName { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}
