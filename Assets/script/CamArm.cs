using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamArm : MonoBehaviour
// 플레이어 위치에 카메라의 기준을 두기
{
    // Start is called before the first frame update

    private Rigidbody rd;
    public Transform player;

    private float camSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z );

    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 1f);
    }
}