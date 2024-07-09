using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PickManager : MonoBehaviour
// 플레이어 위치에 카메라의 기준을 두기
{
    // Start is called before the first frame update
    
    [Range(0.25f, 12f)]
    public float miningSpeed;
    public float miningAnimationDuration;

    [SerializeField]
    private InventoryManager _inventory;
    
    private Rigidbody rd;
    public Transform player;

    private int point = 0;
    
    [SerializeField] private bool isPicking;
    private bool pickAble;
    
    private Animator ani;
    
    public AudioSource audioSource;

    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        pickAble = false;
    }

    IEnumerator setPicking(float data)
    {
        yield return new WaitForSeconds(data);
        isPicking = false;
        pickAble = true;
        yield return new WaitForSeconds(0.2f);
        pickAble = false;
    }

    void Update()
    {
        Move();
        AniControl();
    }

    void Move()
    {
        transform.position = player.position;
    }

    void AniControl()
    {
        ani.SetFloat("MineSpeed", miningAnimationDuration / miningSpeed);
        // Debug.Log(isPicking);
        if (Input.GetKey(KeyCode.Space) && !isPicking)
        {
            isPicking = true;
            ani.SetTrigger("doMine");
            StartCoroutine(setPicking(miningSpeed));
        }  
    }

    private void OnCollisionStay(Collision col)
    {
        // Debug.Log("asd");
        if (col.gameObject.tag == "Ore" & pickAble)
        {
            audioSource.Play();
            Item item = col.gameObject.GetComponent<OreData>().dropItem();
            if (item != null)
            {
                _inventory.AddItem(item);
            }

            pickAble = false;
            // _inventory.AddItem();
            // Debug.Log("interection");
            // Debug.Log(point);
        }
    }
}
