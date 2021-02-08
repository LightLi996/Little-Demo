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
            snake.Init(Snaker.SEGMENT_LENGTH * moveSpeed, Snaker.SEGMENT_LENGTH * rotSpeed);
            return snake;
        }

        public void UpdateExc()
        {
            for (int i = 0; i < _listSnaker.Count; i++)
            {
                _listSnaker[i].MoveControl();
                _listSnaker[i].RotateControl();
                _listSnaker[i].ExcCmd();
            }
        }

        public T CreateCmd<T>(SnakeBlock excer, ICmdParam param) where T : SnakeCmd
        {
            if(param != null)
            {
                ObjectCacheModel cache = SingleModel<ObjectCacheModel>.Get();
                T cmd = cache.GetObjectCache<T>();
                cmd.Gen(excer, param);
                return cmd;
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {

        }
    }
}
