using FirstBlazorApp.DTOs;

namespace FirstBlazorApp.Services
{
    public interface IAnimeCardService
    {
        Task<bool> AddCard(AnimeCardDTO dto);
        Task<List<AnimeCardDTO>> GetCardsAsync();
    }
}
