using System;
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
    protected float moveSpeed;
    protected float rotSpeed;

    private Action _action;


    public void Init(int index, BlockType type, float moveSpeed, float rotSpeed)
    {
        this.index = index;
        this.type = type;
        this.moveSpeed = moveSpeed;
        this.rotSpeed = rotSpeed;
    }

    public void Move()
    {
        Vector3 pos = transform.position;
        pos.z += moveSpeed;
        transform.position = pos;
    }

    public void Rotate()
    {

    }

    public void BeHit()
    {

    }

    public void Store()
    {

    }

    public void ExcAction()
    {
        _action?.Invoke();
    }

    public void AcceptAction(Action action)
    {
        _action = action;
    }

    public Action GetAction()
    {
        return _action;
    }
}
