namespace ShuffleShelf.Server.Models;

public class AlgoliaResult
{
    public List<BookHit> Hits { get; set; }
    public int NbHits { get; set; }
    public int Page { get; set; }
    public int NbPages { get; set; }
    public int HitsPerPage { get; set; }
    public string Params { get; set; }
    public string Index { get; set; }
    public string QueryID { get; set; }
}
