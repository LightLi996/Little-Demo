using System.Collections.Generic;

namespace Framework.Behavior
{
    public class CmdFlow
    {
        private List<ICmdParam[]> _flow = new List<ICmdParam[]>();
        private int _index;

        public void SetSize(int size)
        {
            if (size > _flow.Count)
            {
                ICmdParam[] param = new ICmdParam[(int) CmdType.Max];
                _flow.Add(param);
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
                    _flow[i][j] = null;
                }
            }
        }

        public void Fill(ICmdParam[] param)
        {
            ICmdParam[] current = _flow[_index];
            for (int i = 0; i < (int) CmdType.Max; i++)
            {
                current[i] = param[i];
            }
        }
    }



}


