using Framework;
using Framework.Controller;
using System.Collections;
using System.Collections.Generic;
using Framework.Behavior;
using UnityEngine;

public class ControllerManager : MonoBehaviour, IManager
{
    private Dictionary<int, BaseController> _controllers;

    public void Awake()
    {
        _controllers = new Dictionary<int, BaseController>();
    }

    public void Dispose()
    {
        _controllers.Clear();
    }

    public void UpdateExc()
    {
        foreach (var ctrl in _controllers)
        {
            if (ctrl.Value != null)
            {
                Inject<RotateParam>(ctrl.Key, ctrl.Value.Rotate);
            }
        }
    }

    public void RegisterController(int uid, BaseController ctrl)
    {
        if (_controllers.ContainsKey(uid))
        {
            _controllers[uid] = ctrl;
        }
        else
        {
            _controllers.Add(uid, ctrl);
        }
    }

    private void Inject<T>(int uid, ICmdParam param) where T : ICmdParam
    {
        
    }
}
