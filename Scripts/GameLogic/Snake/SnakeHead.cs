using Framework;
using Framework.Behavior;
using Framework.Manager;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic.Object
{
    public class SnakeHead : SnakeBlock
    {
        private ParamGroup group = new ParamGroup();

        public override ParamGroup ExcCmd()
        {
            SingleManager<SnakeManager>.Get().CreateCmd<RotateCmd>(this, group.GetParam(CmdType.Rotate))?.Exc();
            SingleManager<SnakeManager>.Get().CreateCmd<MoveCmd>(this, group.GetParam(CmdType.Move))?.Exc();
            return group;
        }

        public override void FillParam(ParamGroup param)
        {
            group.SetParam(param);
        }

    }
}
