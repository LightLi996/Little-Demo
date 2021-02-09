namespace Framework.Helper
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

    public interface ICmdParam
    {
        void Reset();
    }

    public enum BlockType
    {
        Head,
        Body,
        Tail,
    }

    public enum CmdType
    {
        Move,
        Rotate,
        Max,
    }

}
