using System.Text.Json;
using System.Text.Json.Serialization;

namespace TidalRPC.Tidal.Models;

internal class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Duration { get; set; }
    public bool StreamReady { get; set; }
    public string StreamStartDate { get; set; }
    public bool AllowStreaming { get; set; }
    public bool PremiumStreamingOnly { get; set; }
    public int NumberOfTracks { get; set; }
    public int NumberOfVideos { get; set; }
    public int NumberOfVolumes { get; set; }
    public string ReleaseDate { get; set; }
    public string Copyright { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
    public string Cover { get; set; }
    public string VibrantColor { get; set; }
    public string VideoCover { get; set; }
    public bool Explicit { get; set; }
    public string Upc { get; set; }
    public int Popularity { get; set; }
    public string AudioQuality { get; set; }
    public string[] AudioModes { get; set; }
    public StrippedArtist[] Artists { get; set; }

}

internal class StrippedArtist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Picture { get; set; }
}