using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickArm : MonoBehaviour
{
    public Transform player;

    private Vector3 pickLocalPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //ArmRealize
        pickLocalPosition = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rightPosition = player.position + transform.right * 10f; // new Vector3(0.5f,0f,-0.2f);
        // transform.position = new Vector3(player.position.x + 0.5f, player.position.y, player.position.z - 0.2f );
        transform.rotation = player.rotation;
        
        ArmRealize();
    }

    void ArmRealize()
    {
        transform.position = player.TransformPoint(pickLocalPosition);
    }
}
