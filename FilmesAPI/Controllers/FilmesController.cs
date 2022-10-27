using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System;
using System.Linq;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO;
using AutoMapper;

namespace FilmesAPI.Controllers
{


    [ApiController]
    [Route("[controller]")] //faz referência ao próprio nome da classe
    public class FilmesController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmesController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        [HttpPost]               //O filme vem do corpo da requisição
        public IActionResult AdcionaFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            Filmes filme = _mapper.Map<Filmes>(filmeDTO);

            //Inicializando o novo objeto filme com as propriedades de nosso filme DTO

            //Exemplo de conversão sem o Uso de DTO
            /*Filmes filme = new Filmes()
            {
                Titulo = filmeDTO.Titulo,
                Genero = filmeDTO.Genero,
                Duracao = filmeDTO.Duracao,
                Diretor = filmeDTO.Diretor
            };*/

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_context.Filmes);  
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {   /*  Lógica por trás do 'firstOrDefault'
            foreach(Filmes filme in filmes)
            {
                if(filme.Id == id) return filme;
            }
            return null;
            */                           //Faz referência a objeto do tipo 'Filmes' por é o que contém dentro da list
            Filmes objetoFilme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(objetoFilme != null)
            {

                ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(objetoFilme);
                /* Exemplo de conversão sem uso de DTO
                 
                ReadFilmeDTO filmeDTO = new ReadFilmeDTO
                {
                    Titulo = objetoFilme.Titulo,
                    Diretor = objetoFilme.Diretor,
                    Duracao = objetoFilme.Duracao,
                    Genero = objetoFilme.Genero,
                    Id = objetoFilme.Id,
                    HoraDaConsulta  = DateTime.Now
                };*/
                return Ok(objetoFilme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTOAtualizado)
        {
            Filmes filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDTOAtualizado, filme);
            /*Exemplo de conversão sem o uso do DTO
             
            filme.Titulo = filmeDTOAtualizado.Titulo;
            filme.Diretor = filmeDTOAtualizado.Diretor;
            filme.Duracao = filmeDTOAtualizado.Duracao;
            filme.Genero = filmeDTOAtualizado.Genero;
            */

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filmes filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
