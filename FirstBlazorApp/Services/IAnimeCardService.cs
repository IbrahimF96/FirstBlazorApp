using FirstBlazorApp.DTOs;

namespace FirstBlazorApp.Services
{
    public interface IAnimeCardService
    {
        Task<List<AnimeCardDTO>> GetCardsAsync();
    }
}
