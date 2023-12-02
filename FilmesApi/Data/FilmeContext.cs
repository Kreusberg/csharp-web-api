using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts)
        : base(opts)
    {
        
    }

//  esta propriedade nos dará o acesso aos dados  
    public DbSet<Filme> Filmes { get; set; }

}
