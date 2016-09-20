namespace Game.Abstractions
{
    public interface IGridModel : IModel
    {
        event System.Action<int, int> TileRemovedEvent;

        int Rows { get; }
        int Columns { get; }
        int NumberOfTypes { get; }
        int NumberOfTiles { get; }
        int Get(int row, int column);
    }
}