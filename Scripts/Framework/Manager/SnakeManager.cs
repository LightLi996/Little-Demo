using Framework.Behavior;
using Framework.Model;
using GameLogic.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Manager
{
    public class SnakeManager : MonoBehaviour, IManager
    {
        public float moveSpeed = 0.1f;
        public float rotSpeed = 0.01f;

        private List<Snaker> _listSnaker;

        public void Awake()
        {
            _listSnaker = new List<Snaker>();

            _listSnaker.Add(CreateSnake());
        }

        public Snaker CreateSnake()
        {
            Snaker snake = new Snaker();
            snake.Init(moveSpeed, rotSpeed);
            return snake;
        }

        public void UpdateExc()
        {
            for (int i = 0; i < _listSnaker.Count; i++)
            {
                _listSnaker[i].Move();
                _listSnaker[i].Rotate();
            }
        }

        public MoveCmd CreateMoveCmd(SnakeBlock excer, ICmdParam param)
        {
            ObjectCacheModel cache = SingleModel<ObjectCacheModel>.Get();
            MoveCmd cmd = cache.GetObjectCache<MoveCmd>();
            cmd.Gen(excer, param);
            return cmd;
        }

        public void Dispose()
        {

        }
    }
}
