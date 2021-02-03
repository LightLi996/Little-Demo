namespace Framework
{
    public interface IManager
    {
        void UpdateExc();
        void Dispose();
    }

    public interface IModel
    {
        void Construct();
        void Dispose();
    }

    public interface IObjectCache
    {
        void Construct();
        void Destruct();
    }

    public enum BlockType
    {
        Head,
        Body,
        Tail,
    }
}
