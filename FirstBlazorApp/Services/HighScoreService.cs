using AutoMapper;
using FirstBlazorApp.Data;
using FirstBlazorApp.DTOs;
using FirstBlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Services
{
    public class HighScoreService : IHighScoreService
    {
        private readonly IDbContextFactory<GameDataContext> _dbFactory;
        private readonly IMapper _mapper;

        public HighScoreService(IDbContextFactory<GameDataContext> dbFactory, IMapper mapper)
        {
            _dbFactory = dbFactory ?? throw new ArgumentNullException(nameof(dbFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<HighScoreDTO>> GetScoresAsync()
        {
            using var context = _dbFactory.CreateDbContext();
            var scores = await context.HighScores.ToListAsync();
            scores = scores.OrderByDescending(x => x.Score).ToList();
            context.Dispose();
            List<HighScoreDTO> _scoreDtos = _mapper.Map<List<HighScoreDTO>>(scores);
            return _scoreDtos;
        }

        public async Task AddScoreAsync(HighScoreDTO highScoreDTO)
        {
            using var context = _dbFactory.CreateDbContext();
            HighScore score = _mapper.Map<HighScore>(highScoreDTO);
            await context.HighScores.AddAsync(score);
            await context.SaveChangesAsync();
            context.Dispose();
        }

    }
}
