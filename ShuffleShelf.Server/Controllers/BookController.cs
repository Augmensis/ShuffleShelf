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
        // Limit results to reduce the opportunity for abuse.
        if (results > 20)
            results = 20;

        // There is a limit of 25 pages, which I think is baked into Shopify
        var randPage = Random.Shared.Next(1, 25);
        var liveBooks = await _algoliaService.FetchBooksAsync(randPage);
        var randBooks = new Dictionary<string, BookHit>();

        // Reduce the available results to the number of books available.
        if(liveBooks.Count < results)
            results = liveBooks.Count;

        // TODO: Add a check for duplicates that cause the total number of available liveBooks
        // to be less than the expected number or results
        while(randBooks.Count < results)
        {
            var randIndex = Random.Shared.Next(0, liveBooks.Count -1);
            var randBook = liveBooks[randIndex];
            randBooks.TryAdd(randBook.ShortTitle, randBook);
        }

        // TODO: Fetch book descriptions, perhaps?
        return Ok(randBooks.Values.ToList());
    }
}
