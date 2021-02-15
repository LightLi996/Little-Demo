using Framework;
using Framework.Controller;
using System.Collections;
using System.Collections.Generic;
using Framework.Behavior;
using Framework.Manager;
using UnityEngine;
using GameLogic.Object;
using Framework.Helper;

namespace Framework.Manager
{
    public class ControllerManager : MonoBehaviour, IManager
    {
        public BaseController[] controllers = new BaseController[2];

        public void Dispose()
        {

        }

        public void UpdateExc()
        {
            for (int i = 0; i < controllers.Length; i++)
            {
                if (controllers[i] == null)
                {
                    continue;
                }

                Snaker snake = SingleManager<SnakeManager>.Get().GetSnake(controllers[i].UID);
                if (snake != null)
                {
                    Inject(snake.RotateControl, controllers[i].Rotate);
                }
            }
        }

        public RotateParam CalculateRotate(int uid, Vector3 target)
        {
            Snaker snake = SingleManager<SnakeManager>.Get().GetSnake(uid);
            RotateParam param = new RotateParam();
            if (snake != null)
            {
                float angle = Vector3.SignedAngle(snake.Direction, target - snake.GetPosition(), Vector3.up);
                if (angle > 0)
                {
                    param.rotSpeed = Mathf.Min(angle, snake.RotateSpeed);
                }
                else
                {
                    param.rotSpeed = Mathf.Max(angle, -snake.RotateSpeed);
                }
            }

            return param;
        }

        private void Inject(ControlAction action, ICmdParam param)
        {
            action?.Invoke(param);
        }
    }

}

