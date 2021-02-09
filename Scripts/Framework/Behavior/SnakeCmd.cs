using Framework.Helper;
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

    public class ParamGroup
    {
        private ICmdParam[] group = new ICmdParam[(int)CmdType.Max];

        public ParamGroup()
        {
            group[(int)CmdType.Move] = new MoveParam();
            group[(int)CmdType.Rotate] = new RotateParam();
        }

        public ICmdParam GetParam(CmdType type)
        {
            return group[(int) type];
        }

        public void SetParam(ParamGroup param)
        {
            for (int i = 0; i < (int) CmdType.Max; i++)
            {
                group[i] = param.GetParam((CmdType) i);
            }
        }

        public void SetParam(CmdType type, ICmdParam param)
        {
            group[(int) type] = param;
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
            excer.ExcAction(this);
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
            excer.ExcAction(this);
        }
    }

}


