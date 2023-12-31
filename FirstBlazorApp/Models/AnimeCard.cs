using FirstBlazorApp.Enums;

namespace FirstBlazorApp.Models
{
    public class AnimeCard
    {
        public Guid Id { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public AnimeSeries Anime { get; set; }

    }
}
