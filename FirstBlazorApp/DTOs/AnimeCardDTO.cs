using FirstBlazorApp.Enums;

namespace FirstBlazorApp.DTOs
{
    public class AnimeCardDTO
    {
        public Guid Id { get; set; }
        public string ImageSource { get; set; } = string.Empty;
        public AnimeSeries Anime { get; set; }

        public bool IsFlipped { get; set; }

        public bool HasMatched { get; set; }
    }
}
