﻿using System.Collections;
using System.Collections.Generic;
using Framework.Behavior;
using Framework.Manager;
using UnityEngine;

namespace Framework.Controller
{
    public class MouseController : BaseController
    {
        private Vector3 _target;
        private bool _reached = true;

        public override void InputCheck()
        {
            if (Input.GetMouseButtonUp(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    _reached = false;
                    _target = hit.point;
                    Debug.Log($"_target :: {_target}");
                }
            }
        }

        public override RotateParam SubmitRotate()
        {
            RotateParam param = new RotateParam();
            if (_reached)
                return param;

            param = SingleManager<ControllerManager>.Get().CalculateRotate(UID, _target);
            if (Mathf.Abs(param.rotSpeed) < 0.0001f)
            {
                _reached = true;
            }
            return param;
        }

    }

}

