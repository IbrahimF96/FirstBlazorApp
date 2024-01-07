using FirstBlazorApp.DTOs;

namespace FirstBlazorApp.Services
{
    public interface IHighScoreService
    {
        Task AddScoreAsync(HighScoreDTO highScoreDTO);
        Task<List<HighScoreDTO>> GetScoresAsync();

    }
}
