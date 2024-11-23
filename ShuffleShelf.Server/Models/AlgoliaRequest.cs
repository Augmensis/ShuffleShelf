namespace ShuffleShelf.Server.Models;

public class AlgoliaRequest
{
    required public string IndexName { get; set; }   
    required public string Params { get; set; }
}
