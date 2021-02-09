using Framework.Behavior;
using Framework.Helper;
using Framework.Model;
using GameLogic.Object;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Manager
{
    public class SnakeManager : MonoBehaviour, IManager
    {
        public float moveSpeed;
        public float rotSpeed;

        private Dictionary<int, Snaker> _dictSnaker;

        public void Awake()
        {
            _dictSnaker = new Dictionary<int, Snaker>();

            _dictSnaker.Add(1, CreateSnake(1));
        }

        public Snaker CreateSnake(int uid)
        {
            Snaker snake = new Snaker();
            snake.Init(uid, Snaker.SEGMENT_LENGTH * moveSpeed, Snaker.SEGMENT_LENGTH * rotSpeed);
            return snake;
        }

        public void UpdateExc()
        {
            foreach (var snake in _dictSnaker.Values)
            {
                snake.MoveControl();
                snake.ExcCmd();
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

        public Snaker GetSnake(int UID)
        {
            Snaker snake = null;
            _dictSnaker.TryGetValue(UID, out snake);
            return snake;
        }

        public void Dispose()
        {

        }
    }
}
