using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    Camera playerCamera;
    CharacterController controller;

    public float speed = 5f;
    public float runSpeed = 8f;

    public bool toggleCameraRotation;

    public float smoothness = 10f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerCamera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true; // 둘러보기 활성화
        } else
        {
            toggleCameraRotation = false; // 둘러보기 비활성화
        }
    }
    void LateUpdate()
    {
        if(toggleCameraRotation != true)
        {
            Vector3 playerRotate = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1));
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smoothness);
        }
    }

}
