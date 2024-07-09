using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Transform slotParent;
    public Slot[] slots;
    public List<ItemCnt> items = new List<ItemCnt>();
    [SerializeField] private int _maxItem;
    [SerializeField] private GameObject invFullText;
    [SerializeField] private AudioSource inventoryFullSound;
    [SerializeField] private AudioSource getItemSound;
    
    
#if UNITY_EDITOR
    private void OnValidate() {
        if (slotParent != null) {
            slots = slotParent.GetComponentsInChildren<Slot>();
        }
    }
#endif

    void Awake() 
    {
        if (slotParent != null) {
            slots = slotParent.GetComponentsInChildren<Slot>();
        }
        FreshSlot();
    }

    IEnumerator InventoryIsFull()
    {
        invFullText.SetActive(true);
        inventoryFullSound.Play();
        yield return new WaitForSeconds(0.8f);
        invFullText.SetActive(false);
        yield break;
    }
    
    public void FreshSlot() {
        int i = 0;
        // Debug.Log("슬롯 길이" + slots.Length);
        // Debug.Log(items.Count);
        for (; i < items.Count && i < slots.Length; i++) {
            slots[i].Item = items[i];
        }
        for (; i < slots.Length; i++) {
            slots[i].Item = null;
        }
    }

    public void PopItem(Item item, int deleteItem)
    {
        int index = items.FindIndex(item1 => item1.item.itemName.Equals(item.itemName) && item1.itemCount >= 1);
        if (index != -1)
        {
            items[index].itemCount -= deleteItem;
        }
    }
    
    public void AddItem(Item item) 
    {
        int index = items.FindIndex(item1 => item1.item.itemName.Equals(item.itemName) && item1.itemCount < _maxItem);
        if (items.Count < slots.Length)
        {
            getItemSound.Play();
            if (index != -1)
            {
                if (items[index].itemCount == _maxItem)
                {
                    ItemCnt itemCnt = new ItemCnt(item, 1);
                    items.Add(itemCnt);
                }
                else
                {
                    items[index].itemCount += 1;
                }
            }
            else
            {
                ItemCnt itemCnt = new ItemCnt(item, 1);
                items.Add(itemCnt);
            }
        }
        else if (items.Count == slots.Length)
        {
            if (index != -1)
            {
                if (items[index].itemCount < _maxItem)
                {
                    getItemSound.Play();
                    items[index].itemCount += 1;
                }
                else
                {
                    StartCoroutine(InventoryIsFull());
                    Debug.Log("Slot is full");
                }
            }
        }
        else
        {
            StartCoroutine(InventoryIsFull());
            Debug.Log("Slot is full");
        }
        FreshSlot();
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                Debug.Log(webRequest);
            }
        }
    }
}