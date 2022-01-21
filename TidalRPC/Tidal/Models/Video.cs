namespace TidalRPC.Tidal.Models;

internal class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int VolumeNumber { get; set; }
    public int TrackNumber { get; set; }
    public string ReleaseDate { get; set; }
    public string ImagePath { get; set; }
    public string ImageId { get; set; }
    public string VibrantColor { get; set; }
    public int Duration { get; set; }
    public string Quality { get; set; }
    public bool StreamReady { get; set; }
    public string StreamStartDate { get; set; }
    public bool AllowStreaming { get; set; }
    public bool Explicit { get; set; }
    public int Popularity { get; set; }
    public string Type { get; set; }
    public string AdsUrl { get; set; }
    public bool AdsPrePaywallOnly { get; set; }
    public StrippedArtist[] Artists { get; set; }
    public StrippedAlbum Album { get; set; }
}
