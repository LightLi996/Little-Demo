using System;
using System.Collections.Generic;
using UnityEngine;

public class Snaker
{
    public Vector3 target;

    private List<SnakeBlock> _listBlock = new List<SnakeBlock>();

    private int _index;
    private float moveSpeed;
    private float rotSpeed;

    public void Init(float moveSpeed, float rotSpeed)
    {
        _index = 0;
        this.moveSpeed = moveSpeed;
        this.rotSpeed = rotSpeed;
        GenerateBlock(_index++, BlockType.Head);
        GenerateBlock(_index++, BlockType.Body);
        GenerateBlock(_index++, BlockType.Tail);

        SetPosition();
    }

    public void Move()
    {
        
    }

    public void Rotate()
    {
        
    }

    private void GenerateBlock(int index, BlockType type)
    {
        GameObject go = GameObject.Instantiate(Resources.Load(GameMain.BLUE_BLOCK_PATH + type.ToString())) as GameObject;
        SnakeBlock block = go.GetComponent<SnakeBlock>();
        block.Init(index, type);
        _listBlock.Add(block);
    }

    private void SetPosition()
    {
        Vector3 pos = Vector3.zero;
        for (int i = 0; i < _listBlock.Count; i++)
        {
            _listBlock[i].gameObject.transform.position = pos;
            pos.z -= 1.04f;
        }
    }
}
