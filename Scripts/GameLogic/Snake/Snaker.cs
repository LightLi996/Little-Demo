using Framework;
using Framework.Behavior;
using Framework.Manager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.Object
{
    public class Snaker
    {
        private static readonly float _SEGMENT_LENGTH = 1.04f;

        public Vector3 target;

        private List<SnakeBlock> _listBlock = new List<SnakeBlock>();

        private int _length;
        private float _moveSpeed;
        private float _rotSpeed;

        private List<ICmdParam[]> _cmdParamFlow = new List<ICmdParam[]>();

        public void Init(float moveSpeed, float rotSpeed)
        {
            _length = 0;
            _moveSpeed = moveSpeed;
            _rotSpeed = rotSpeed;
            GenerateBlock(_length++, BlockType.Head);
            GenerateBlock(_length++, BlockType.Body);
            GenerateBlock(_length++, BlockType.Tail);

            SetPosition();
        }

        public void MoveControl()
        {
            MoveParam param = new MoveParam();
            param.moveSpeed = _moveSpeed;
            for (int i = 0; i < _cmdParamFlow.Count; i++)
            {
                _cmdParamFlow[i][(int) CmdType.Move] = param;
            }
        }

        public void RotateControl()
        {
            for (int i = _cmdParamFlow.Count - 1; i > 0; i--)
            {
                _cmdParamFlow[i][(int)CmdType.Rotate] = _cmdParamFlow[i - 1][(int) CmdType.Rotate];
            }

            var angle = _rotSpeed;
            RotateParam param = new RotateParam();
            param.rotSpeed = angle;
            _cmdParamFlow[0][(int) CmdType.Rotate] = param;
        }

        public void ExcCmd()
        {
            for (int i = 0; i < _cmdParamFlow.Count; i++)
            {
                var param = _cmdParamFlow[i];
                SingleManager<SnakeManager>.Get().CreateCmd<RotateCmd>(_listBlock[i], param[(int)CmdType.Rotate])?.Exc();
                SingleManager<SnakeManager>.Get().CreateCmd<MoveCmd>(_listBlock[i], param[(int)CmdType.Move])?.Exc();
            }
        }

        private void GenerateBlock(int index, BlockType type)
        {
            GameObject go = GameObject.Instantiate(Resources.Load(GameMain.BLUE_BLOCK_PATH + type.ToString())) as GameObject;
            SnakeBlock block = go.GetComponent<SnakeBlock>();
            block.Init(index, type);
            _listBlock.Add(block);
            _cmdParamFlow.Add(new ICmdParam[(int) CmdType.Max]);
        }

        private void SetPosition()
        {
            Vector3 pos = Vector3.zero;
            for (int i = 0; i < _listBlock.Count; i++)
            {
                _listBlock[i].gameObject.transform.position = pos;
                pos.z -= _SEGMENT_LENGTH;
            }
        }
    }
}
