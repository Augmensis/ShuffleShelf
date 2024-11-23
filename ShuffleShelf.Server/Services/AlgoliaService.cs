using ShuffleShelf.Server.Models;
using System.Text;
using System.Text.Json;

namespace ShuffleShelf.Server.Services;

public class AlgoliaService
{
    private readonly IConfiguration _config;
    private readonly ILogger<AlgoliaService> _logger;
    public AlgoliaService(IConfiguration config,
        ILogger<AlgoliaService> logger) 
    { 
        _config = config;
        _logger = logger;
    }

    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<List<BookHit>> FetchBooksAsync(int page = 1)
    {
        string algoliaUrl = "https://ar33g9njgj-dsn.algolia.net/1/indexes/*/queries";

        // Payload
        var payload = new
        {
            requests = new AlgoliaRequest[]
            {
                // TODO: Factor out params into user-configurable payload
                new AlgoliaRequest
                {
                    IndexName = "shopify_products",
                    Params = $"clickAnalytics=true" +
                    $"&facets=%5B%22author%22%2C%22availableConditions%22%2C%22bindingType%22%2C%22console%22%2C%22hierarchicalCategories.lvl0%22%2C%22platform%22%2C%22priceRanges%22%2C%22productType%22%2C%22publisher%22%5D" +
                    $"&filters=collection_ids%3A520304558353%20AND%20inStock%3Atrue%20AND%20fromPrice%20%3E%200&highlightPostTag=__%2Fais-highlight__" +
                    $"&highlightPreTag=__ais-highlight__" +
                    $"&maxValuesPerFacet=10" +
                    $"&page={page}" +
                    $"&tagFilters=" +
                    $"&userToken=anonymous-68bed8bf-2ce3-4ab7-bd55-39d457dad716"
                }
            }
        };

        var requestBody = JsonSerializer.Serialize(payload, new JsonSerializerOptions {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        // Create HttpContent with proper headers
        var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

        // Add required headers
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("x-algolia-api-key", _config["Algolia:ApiKey"]);
        _httpClient.DefaultRequestHeaders.Add("x-algolia-application-id", _config["Algolia:AppId"]);

        // Send POST request to algolia backend
        var response = await _httpClient.PostAsync(algoliaUrl, httpContent);

        // Ensure the response is successful
        response.EnsureSuccessStatusCode();

        // Return response content as string
        var jsonResults = await response.Content.ReadAsStringAsync();

        var algoliaResponse = JsonSerializer.Deserialize<AlgoliaResponse>(jsonResults, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        return algoliaResponse?.Results?.First().Hits;
    }
}
