using FirstBlazorApp.DTOs;
using FirstBlazorApp.Data;
using FirstBlazorApp.Models;
using AutoMapper;

namespace FirstBlazorApp.Services
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnimeCard, AnimeCardDTO>();
            CreateMap<AnimeCardDTO, AnimeCard>();

            CreateMap<HighScore, HighScoreDTO>();
            CreateMap<HighScoreDTO, HighScore>();
        }
    }
}
