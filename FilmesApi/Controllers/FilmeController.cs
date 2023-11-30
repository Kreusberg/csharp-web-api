using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private static List<Filme> filmes = new();
    private static int id = 0;

    [HttpPost] //             Aqui é indicado de que o parâmetro virá do corpo da requisição
    public IActionResult AdicionaFilme([FromBody] Filme filme)
    {

        filme.Id = id++;
        filmes.Add(filme); //                              parâmetros necessários para retornar este valor
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id}, filme);
//                          método executado para retornar este valor ||||       objeto criado         
    }

    [HttpGet]
    public IEnumerable<Filme> RecuperaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        return Ok(filme);
    }
}
