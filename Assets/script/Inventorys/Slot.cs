using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Slot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image image;
    [SerializeField] private TMP_Text count;

    private InventoryManager _inventoryManager;
    
    private ItemCnt _item;
    public ItemCnt Item {
        get
        {
            // Debug.Log("내아이템"+ _item);
            return _item;
        }
        set { 
            // Debug.Log("값" + value);
            _item = value;
            if (_item != null) {
                image.sprite = Item.item.itemImage;
                count.text = "" + Item.itemCount;
                count.color = new Color(0.953f, 0.688f, 0.42f, 1);
                image.color = new Color(1, 1, 1, 1);
            } else {
                count.color = new Color(0.953f, 0.688f, 0.42f, 0);
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }

    private void Start()
    {
        _inventoryManager = GetComponent<InventoryManager>();
    }

    private ItemCnt CopyItem(ItemCnt item)
    {
        ItemCnt newItem = new ItemCnt(item.item, item.itemCount);
        return newItem;
    }
        
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item != null)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("스왑");
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                if (_item != null)
                {
                    Debug.Log(_item.item);
                    Debug.Log(_inventoryManager);
                    // _inventoryManager.PopItem(_item.item, 1);
                }
            }
        }
    }
}
