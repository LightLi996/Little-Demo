using GameLogic.Object;

namespace Framework.Behavior
{
    public struct MoveParam : ICmdParam
    {
        public float moveSpeed;
        
        public void Reset()
        {
            moveSpeed = 0;
        }
    }

    public struct RotateParam : ICmdParam
    {
        public float rotSpeed;

        public void Reset()
        {
            rotSpeed = 0;
        }
    }


    public abstract class SnakeCmd : IObjectCache
    {
        public SnakeBlock excer;
        public CmdType type;

        public virtual void Construct() { }

        public virtual void Destruct()
        {
            excer.Dispose();
        }

        public abstract void Gen(SnakeBlock excer, ICmdParam param);
        public abstract void Exc();
    }


    public class MoveCmd : SnakeCmd
    {
        public MoveParam moveParam;

        public override void Gen(SnakeBlock excer, ICmdParam param)
        {
            moveParam = (MoveParam)param;
            type = CmdType.Move;
            this.excer = excer;
        }

        public override void Exc()
        {
            excer.ExcCmd(this);
        }
    }

    public class RotateCmd : SnakeCmd
    {
        public RotateParam rotParam;

        public override void Gen(SnakeBlock excer, ICmdParam param)
        {
            rotParam = (RotateParam)param;
            type = CmdType.Rotate;
            this.excer = excer;
        }

        public override void Exc()
        {
            excer.ExcCmd(this);
        }
    }

}


