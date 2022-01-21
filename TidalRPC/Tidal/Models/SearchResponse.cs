namespace TidalRPC.Tidal.Models;

internal class SearchResponse
{
    public SearchItem<Artist> Artists { get; set; }
    public SearchItem<Album> Albums { get; set; }
    public SearchItem<Playlist> Playlists { get; set; }
    public SearchItem<Track> Tracks { get; set; }
    public SearchItem<Video> Videos { get; set; }
    public dynamic[] Genres { get; set; }
    public dynamic[] TopHits { get; set; }
}