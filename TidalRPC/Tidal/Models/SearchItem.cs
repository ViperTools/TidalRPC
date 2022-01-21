namespace TidalRPC.Tidal.Models;

internal class SearchItem<T>
{
    public int Limit { get; set; }
    public int Offset { get; set; }
    public int TotalNumberOfItems { get; set; }
    public T[] Items { get; set; }
}
