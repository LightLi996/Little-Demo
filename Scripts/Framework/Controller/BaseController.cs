using System.Collections;
using System.Collections.Generic;
using Framework.Behavior;
using Framework.Manager;
using UnityEngine;

namespace Framework.Controller
{
    public abstract class BaseController : MonoBehaviour
    {
        public int UID;

        public RotateParam Rotate => _rotate;

        private RotateParam _rotate = new RotateParam();

        public void Reset()
        {
            _rotate = new RotateParam();
        }

        public void Update()
        {
            InputCheck();
            _rotate = SubmitRotate();
        }

        public abstract void InputCheck();
        public abstract RotateParam SubmitRotate();

    }

}

