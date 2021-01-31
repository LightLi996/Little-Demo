using System;
using System.Collections.Generic;
using UnityEngine;

public class Snaker : MonoBehaviour
{
    public Vector3 target;

    private List<SnakeBlock> _listBlock = new List<SnakeBlock>();

    private int _index;

    public void Init(float moveSpeed, float rotSpeed)
    {
        _index = 0;
        GenerateBlock(_index++, BlockType.Head, moveSpeed, rotSpeed);
        GenerateBlock(_index++, BlockType.Body, moveSpeed, rotSpeed);
        GenerateBlock(_index++, BlockType.Tail, moveSpeed, rotSpeed);

        SetPosition();
    }

    public void Move()
    {
        for(int i = 0; i < _listBlock.Count; i++)
        {
            _listBlock[i].Move();
        }
    }

    public void Rotate()
    {
        Vector3 pos = transform.position;
        Vector3 dir = target - pos;

    }

    private void GenerateBlock(int index, BlockType type, float moveSpeed, float rotSpeed)
    {
        GameObject go = Instantiate(Resources.Load(GameMain.BLUE_BLOCK_PATH + type.ToString())) as GameObject;
        SnakeBlock block = go.GetComponent<SnakeBlock>();
        block.Init(index, type, moveSpeed, rotSpeed);
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
