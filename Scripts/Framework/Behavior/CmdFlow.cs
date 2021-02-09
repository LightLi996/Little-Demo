using Framework.Helper;
using System.Collections.Generic;

namespace Framework.Behavior
{
    public class CmdFlow
    {
        private List<ParamGroup> _flow = new List<ParamGroup>();
        private int _index;

        public int Count => _flow.Count;

        public void InitCmdParam(float moveSpeed)
        {
            for (int i = 0; i < _flow.Count; i++)
            {
                _flow[i] = new ParamGroup();
                MoveParam param = new MoveParam();
                param.moveSpeed = moveSpeed;
                _flow[i].SetParam(CmdType.Move, param);
            }
        }

        public void SetSize(int size)
        {
            if (size > _flow.Count)
            {
                while (_flow.Count <= size)
                {
                    ParamGroup param = new ParamGroup();
                    _flow.Add(param);
                }
            }
            else
            {
                while (_flow.Count > size)
                {
                    _flow.RemoveAt(_flow.Count - 1);
                }
            }
        }

        public void Clear()
        {
            _index = 0;
            for (int i = 0; i < _flow.Count; i++)
            {
                for (int j = 0; j < (int) CmdType.Max; j++)
                {
                    _flow[i] = null;
                }
            }
            _flow.Clear();
        }

        public void Enqueue(ParamGroup param)
        {
            ParamGroup current = _flow[_index];
            for (int i = 0; i < (int) CmdType.Max; i++)
            {
                current.SetParam(param);
            }

            _index++;
        }

        public ParamGroup Dequeue()
        {
            if (_index >= _flow.Count)
            {
                _index = 0;
            }

            return _flow[_index];
        }
    }



}


