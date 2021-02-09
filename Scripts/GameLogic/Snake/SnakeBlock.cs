using Framework;
using Framework.Behavior;
using System;
using System.Collections.Generic;
using Framework.Manager;
using UnityEngine;
using Framework.Helper;

namespace GameLogic.Object
{
    public abstract class SnakeBlock : MonoBehaviour
    {
        protected int index;
        protected BlockType type;

        private Dictionary<CmdType, Action<SnakeCmd>> _actions = new Dictionary<CmdType, Action<SnakeCmd>>();

        public abstract ParamGroup ExcCmd();

        public abstract void FillParam(ParamGroup param);


        public virtual void Init(int index, int size, float speed)
        {
            RegisterCmd();
            this.index = index;
        }

        public void ExcAction(SnakeCmd cmd)
        {
            Action<SnakeCmd> func;
            if (_actions.TryGetValue(cmd.type, out func))
            {
                func?.Invoke(cmd);
            }
        }

        private void RegisterCmd()
        {
            _actions.Clear();
            _actions.Add(CmdType.Move, OnMove);
            _actions.Add(CmdType.Rotate, OnRotate);
        }

        private void OnRotate(SnakeCmd cmd)
        {
            float rotSpeed = ((RotateCmd)cmd).rotParam.rotSpeed;
            Vector3 rot = Vector3.up;
            transform.Rotate(rot * rotSpeed);
        }

        private void OnMove(SnakeCmd cmd)
        {
            float moveSpeed = ((MoveCmd)cmd).moveParam.moveSpeed;
            Vector3 pos = transform.position;
            pos += transform.forward * moveSpeed;
            transform.position = pos;
        }

        public virtual void Dispose()
        {

        }
    }
}

