using Microsoft.AspNetCore.Mvc;
using ShuffleShelf.Server.Models;
using ShuffleShelf.Server.Services;
using System.Text.Json;

namespace ShuffleShelf.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly AlgoliaService _algoliaService;

    public BookController(HttpClient httpClient,
        AlgoliaService algoliaService)
    {
        _algoliaService = algoliaService;
    }

    [HttpGet("random")]
    public async Task<IActionResult> GetRandomBook()
    {
        var randPage = Random.Shared.Next(1, 25);
        var liveBooks = await _algoliaService.FetchBooksAsync(randPage);
        var randBook = Random.Shared.Next(1, liveBooks.Count - 1);
        return Ok(liveBooks[randBook]);
    }

    [HttpGet("random/{results:int}")]
    public async Task<IActionResult> GetRandomBooks(int results)
    {
        var randPage = Random.Shared.Next(1, 25);
        var liveBooks = await _algoliaService.FetchBooksAsync(randPage);
        var randBooks = new List<BookHit>();
        for (int i = 0; i < results; i++)
        {
            var randBook = Random.Shared.Next(1, liveBooks.Count - 1);
            randBooks.Add(liveBooks[randBook]);
        }
        return Ok(randBooks);
    }
}
