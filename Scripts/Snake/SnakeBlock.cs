using System;
using System.Collections.Generic;
using UnityEngine;


public enum BlockType
{
    Head,
    Body,
    Tail,
}


public abstract class SnakeBlock : MonoBehaviour
{
    protected int index;
    protected BlockType type;

    private Dictionary<CmdType, Action<SnakeCmd>> _actions = new Dictionary<CmdType, Action<SnakeCmd>>();


    public void Init(int index, BlockType type)
    {
        RegisterCmd();
        this.index = index;
        this.type = type;
    }

    public void BeHit()
    {

    }

    public void Store()
    {

    }

    public void ExcCmd(SnakeCmd cmd)
    {
        Action<SnakeCmd> func;
        if (_actions.TryGetValue(cmd.type, out func))
        {
            func?.Invoke(cmd);
        }
    }

    public void Dispose()
    {

    }


    private void RegisterCmd()
    {
        _actions.Clear();
        _actions.Add(CmdType.Rotate, Rotate);
        _actions.Add(CmdType.Move, Move);
    }

    private void Rotate(SnakeCmd cmd)
    {
        float rotSpeed = ((RotateCmd) cmd).rotParam.rotSpeed;
        Vector3 rot = Vector3.up;
        transform.Rotate(rot * rotSpeed);
    }

    private void Move(SnakeCmd cmd)
    {
        float moveSpeed = ((MoveCmd) cmd).moveParam.moveSpeed;
        Vector3 pos = transform.position;
        pos.z += moveSpeed;
        transform.position = pos;
    }
}
