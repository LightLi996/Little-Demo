using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeManager : MonoBehaviour, IDispose
{
    public float moveSpeed = 0.1f;
    public float rotSpeed = 0.01f;

    private List<Snaker> _listSnaker;

    public void Awake()
    {
        _listSnaker = new List<Snaker>();

        _listSnaker.Add(CreateSnake());
    }
    
    public Snaker CreateSnake()
    {
        Snaker snake = new Snaker();
        snake.Init(moveSpeed, rotSpeed);
        return snake;
    }

    public void UpdateExc()
    {
        for(int i = 0; i < _listSnaker.Count; i++)
        {
            _listSnaker[i].Move();
        }
    }

    public void Dispose()
    {

    }
}
