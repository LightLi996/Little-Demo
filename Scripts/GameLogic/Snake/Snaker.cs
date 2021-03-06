﻿using Framework;
using Framework.Behavior;
using Framework.Helper;
using Framework.Manager;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameLogic.Object
{
    public class Snaker
    {
        public static readonly float SEGMENT_LENGTH = 1.04f;

        public int UID => _uid;
        public int Size => _size;
        public float MoveSpeed => _moveSpeed;
        public float RotateSpeed => _rotSpeed;
        public Vector3 Direction => _listBlock[0].gameObject.transform.forward;


        private int _uid;
        private List<SnakeBlock> _listBlock = new List<SnakeBlock>();

        private int _length;
        private float _moveSpeed;
        private float _rotSpeed;
        private int _size;
        private int _cmdPtr;

        private ParamGroup _cacheParam  = new ParamGroup();

        public void Init(int uid, float moveSpeed, float rotSpeed)
        {
            _uid = uid;
            _length = 0;
            _cmdPtr = 0;
            _moveSpeed = moveSpeed;
            _rotSpeed = rotSpeed;
            _size = (int)(1 / _moveSpeed);

            Create();
        }

        public Vector3 GetPosition()
        {
            return _listBlock[0].gameObject.transform.position;
        }

        public void MoveControl()
        {
            MoveParam param = new MoveParam();
            param.moveSpeed = _moveSpeed;
            _cacheParam.SetParam(CmdType.Move, param);
        }

        public void RotateControl(ICmdParam param)
        {
            _cacheParam.SetParam(CmdType.Rotate, param);
        }

        public void ExcCmd()
        {
            _listBlock[0].FillParam(_cacheParam);
            for (int i = 0; i < _listBlock.Count; i++)
            {
                ParamGroup param = _listBlock[i].ExcCmd();
                if (i < _listBlock.Count - 1)
                {
                    _listBlock[i + 1].FillParam(param);
                }
            }
        }

        private void Create()
        {
            GenerateBlock<SnakeHead>(_length++, _size, _moveSpeed);
            GenerateBlock<SnakeBody>(_length++, _size, _moveSpeed);
            GenerateBlock<SnakeTail>(_length++, _size, _moveSpeed);
            SetPosition();
        }

        private void GenerateBlock<T>(int index, int size, float initialSpeed) where T : SnakeBlock
        {
            string name = typeof(T).Name;
            GameObject go = GameObject.Instantiate(Resources.Load(GameMain.BLUE_BLOCK_PATH + name)) as GameObject;
            T block = go.GetComponent<T>();
            block.Init(index, size, initialSpeed);
            _listBlock.Add(block);
        }

        private void SetPosition()
        {
            Vector3 pos = Vector3.zero;
            for (int i = 0; i < _listBlock.Count; i++)
            {
                _listBlock[i].gameObject.transform.position = pos;
                pos.z -= SEGMENT_LENGTH;
            }
        }
    }
}
