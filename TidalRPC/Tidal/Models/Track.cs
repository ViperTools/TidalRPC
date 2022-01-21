namespace TidalRPC.Tidal.Models;

internal class Track
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public double ReplayGain { get; set; }
    public double Peak { get; set; }
    public bool AllowStreaming { get; set; }
    public bool StreamReady { get; set; }
    public string StreamStartDate { get; set; }
    public bool PremiumStreamingOnly { get; set; }
    public int TrackNumber { get; set; }
    public int VolumeNumber { get; set; }
    public string Version { get; set; }
    public int Popularity { get; set; }
    public string Copyright { get; set; }
    public string Url { get; set; }
    public string Isrc { get; set; }
    public bool Editable { get; set; }
    public bool Explicit { get; set; }
    public string AudioQuality { get; set; }
    public string[] AudioModes { get; set; }
    public StrippedArtist[] Artists { get; set; }
    public StrippedAlbum Album { get; set; }
    public Dictionary<string, string> Mixes { get; set; }
}

internal class StrippedAlbum
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Cover { get; set; }
    public string VibrantColor { get; set; }
    public string VideoCover { get; set; }
    public string ReleaseDate { get; set; }
}