using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class playerManiger : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rd;
    private float Speed = 8.0f;
    private float AngleSpeed = 5f;
    private int animation = 0; // 애니메이션 불값 실행해야 하는가?
    private bool isMove; // 움직이고 있는가?

    private Animator ani;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        AniContorl();
        LookMouse();
        isMove = false;
    }

    void Move()
    {
        float zMove = Input.GetAxisRaw("Vertical");
        float xMove = Input.GetAxisRaw("Horizontal");
        if (zMove+xMove != 0)
        {
            isMove = true;
        }

        Vector3 moveDir = new Vector3(xMove, 0, zMove).normalized;
        rd.velocity = moveDir * Speed;

    }

    void LookMouse()
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane GroupPlane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;

        if(GroupPlane.Raycast(cameraRay, out rayLength))

        {		

            Vector3 pointTolook = cameraRay.GetPoint(rayLength);

            transform.LookAt(new Vector3(pointTolook.x, transform.position.y, pointTolook.z));

        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,transform.forward*20f);
    }

    void AniContorl()
    {
        ani.SetBool("IsMove", isMove);
    }
}