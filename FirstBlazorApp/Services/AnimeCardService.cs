using AutoMapper;
using FirstBlazorApp.Data;
using FirstBlazorApp.DTOs;
using FirstBlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstBlazorApp.Services
{
    public class AnimeCardService : IAnimeCardService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public AnimeCardService(DataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> AddCard(AnimeCardDTO dto)
        {
            try
            {
                AnimeCard cardToAdd = _mapper.Map<AnimeCard>(dto);
                await _context.AddAsync(cardToAdd);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                return false;
            }
        }

        public async Task<List<AnimeCardDTO>> GetCardsAsync()
        {
            List<AnimeCard> _cards = await _context.AnimeCards.ToListAsync();
            List<AnimeCardDTO> _cardDtos = _mapper.Map<List<AnimeCardDTO>>(_cards);
            return _cardDtos;
        }

    }
}
