namespace TidalRPC.Tidal.Models;

internal class Artist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] ArtistTypes { get; set; }
    public string Url { get; set; }
    public string Picture { get; set; }
    public int Popularity { get; set; }
    public ArtistRole[] ArtistRoles { get; set; }
    public Dictionary<string, string> Mixes { get; set; }
}

internal class ArtistRole
{
    public int CategoryId { get; set; }
    public string Category { get; set; }
}
