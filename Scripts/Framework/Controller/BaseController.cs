using System.Collections;
using System.Collections.Generic;
using Framework.Behavior;
using UnityEngine;

namespace Framework.Controller
{
    public abstract class BaseController : MonoBehaviour
    {
        public RotateParam Rotate => _rotate;

        private RotateParam _rotate = new RotateParam();

        public void Reset()
        {
            _rotate = new RotateParam();
        }

        public void Update()
        {
            _rotate = SubmitRotate();
        }

        public abstract RotateParam SubmitRotate();

    }

}

