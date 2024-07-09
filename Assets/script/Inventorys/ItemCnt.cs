using System;
using UnityEngine;

[Serializable]
public class ItemCnt
{
    public int itemCount;
    public Item item;

    public ItemCnt(Item item, int itemCount)
    {
        this.item = item;
        this.itemCount = itemCount;
    }
}