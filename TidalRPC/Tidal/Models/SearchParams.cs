namespace TidalRPC.Tidal.Models;

internal class SearchParams
{
    public string Query;
    public int Limit = 1;
    public int Offset = 0;
    public string[] Types =
    {
        "ARTISTS",
        "ALBUMS",
        "TRACKS",
        "VIDEOS",
        "PLAYLISTS"
    };
    public bool IncludeContributors = true;
    public string CountryCode = "US";
    public string Locale = "en_US";
    public string DeviceType = "BROWSER";
}
