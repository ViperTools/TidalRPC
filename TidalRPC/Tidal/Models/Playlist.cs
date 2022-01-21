namespace TidalRPC.Tidal.Models;

internal class Playlist
{
    public string UUID { get; set; }
    public string Title { get; set; }
    public int NumberOfTracks { get; set; }
    public int NumberOfVideos { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public string LastUpdated { get; set; }
    public string Created { get; set; }
    public string Type { get; set; }
    public bool PublicPlaylist { get; set; }
    public string Url { get; set; }
    public string Image { get; set; }
    public int Popularity { get; set; }
    public string SquareImage { get; set; }
    public StrippedArtist[] PromotedArtists { get; set; }
    public string LastItemAddedAt { get; set; }
}