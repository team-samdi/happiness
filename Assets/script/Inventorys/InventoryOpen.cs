using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpen : MonoBehaviour
{
    [SerializeField] private bool openCheck;
    
    [SerializeField]
    private GameObject target;
    
    void Start()
    {
        openCheck = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            openCheck = !openCheck;
        }
        target.SetActive(openCheck);
    }
}
