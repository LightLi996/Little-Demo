using Framework;
using Framework.Behavior;
using Framework.Manager;
using UnityEngine;

namespace GameLogic.Object
{
    public class SnakeTail : SnakeBlock
    {
        public CmdFlow cmdFlow = new CmdFlow();

        public override void Init(int index, int size, float speed)
        {
            base.Init(index, size, speed);

            cmdFlow.SetSize(size);
            cmdFlow.InitCmdParam(speed);
        }

        public override ParamGroup ExcCmd()
        {
            ParamGroup param = cmdFlow.Dequeue();
            SingleManager<SnakeManager>.Get().CreateCmd<RotateCmd>(this, param.GetParam(CmdType.Rotate))?.Exc();
            SingleManager<SnakeManager>.Get().CreateCmd<MoveCmd>(this, param.GetParam(CmdType.Move))?.Exc();
            return param;
        }

        public override void FillParam(ParamGroup param)
        {
            cmdFlow.Enqueue(param);
        }
    }
}
