using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class FilmeContext : DbContext
    {
        
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
          
        }

        public DbSet<Filmes> Filmes { get; set; }
    }
}
