namespace ShuffleShelf.Server.Models;

public class BookHit
{
    public long Id { get; set; }
    public string ShortTitle { get; set; }
    public string LongTitle { get; set; }
    public string LegacyTitle { get; set; }
    public string Author { get; set; }
    public string Isbn10 { get; set; }
    public string Isbn13 { get; set; }
    public decimal FromPrice { get; set; }
    public string ImageURL { get; set; }
    public string DatePublished { get; set; }
    public string ProductHandle { get; set; }
    public bool IsUk { get; set; }
    public bool IsUsa { get; set; }
    public bool IsLowStock { get; set; }
    public bool IsHighStock { get; set; }
    public bool IsUsed { get; set; }
    public bool IsNew { get; set; }

}
