using AutoMapper;
using FilmesAPI.Data.DTO;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        { 
            //Converte do 1º específicado para o 2º
        CreateMap<CreateFilmeDTO, Filmes>();
        CreateMap<Filmes, ReadFilmeDTO>();
        CreateMap<UpdateFilmeDTO, Filmes>();
        }
    }
}
