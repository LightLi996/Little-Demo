using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    private Transform trans;
    private Vector3 vec3;
    private float speed = 0.1f;

    public void Awake()
    {
        trans = this.gameObject.transform;
        vec3 = new Vector3(0.1f, 0, 0.1f);
    }

    public void OnEnable()
    {
        Debug.LogWarning("Enable!");
    }

    public void OnDisable()
    {
        Debug.LogWarning("Enable!");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogWarning("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        ControlInput();
    }

    public void OnDestroy()
    {
        Debug.LogWarning("Start!");
    }


    public void ControlInput()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            Attack();
        }

        if(Input.GetKey(KeyCode.UpArrow))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveBack();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }


    public void Rotate()
    {
        Quaternion rotate = trans.localRotation;
        rotate = Quaternion.Euler(vec3);
        vec3.x += 0.1f;
        vec3.z += 0.1f;
        trans.localRotation = rotate;
    }


    public void Attack()
    {
        
    }


    private void MoveForward()
    {
        Vector3 pos = trans.localPosition;
        pos.z += speed;
        trans.localPosition = pos;
    }

    private void MoveBack()
    {
        Vector3 pos = trans.localPosition;
        pos.z -= speed;
        trans.localPosition = pos;
    }

    private void MoveLeft()
    {
        Vector3 pos = trans.localPosition;
        pos.x -= speed;
        trans.localPosition = pos;
    }

    private void MoveRight()
    {
        Vector3 pos = trans.localPosition;
        pos.x += speed;
        trans.localPosition = pos;
    }
}
