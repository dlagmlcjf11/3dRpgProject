using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float hAxis;
    float vAxis;

    Vector3 moveVec;
    Rigidbody rigid;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void InputButton() {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
    }

    void Update()
    {
        InputButton();
        Move();
    }

    void Move() {
        moveVec = new Vector3(hAxis, 0 ,vAxis).normalized;
        rigid.velocity = moveVec * moveSpeed;
        transform.LookAt(transform.position + moveVec);
    }
}
