using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using FilmesAPI.Models;
using System;
using System.Linq;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] //faz referência ao próprio nome da classe
    public class FilmesController : ControllerBase
    {
        private static List<Filmes> filmes = new List<Filmes>();
        private static int Id = 1;
        [HttpPost]               //O filme vem do corpo da requisição
        public IActionResult AdcionaFilme([FromBody] Filmes filme)
        {
            filme.Id = Id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }
        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(filmes);  
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
            Filmes objetoFilme = filmes.FirstOrDefault(f => f.Id == id);

            if(objetoFilme != null)
            {
                return Ok(objetoFilme);
            }
            return NotFound();
        }
    }
}
