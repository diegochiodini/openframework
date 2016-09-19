namespace Game.Abstractions
{
    public interface ITile : IGameInterface
    {
        int Type { get; }
        void Init(int type);
    }
}