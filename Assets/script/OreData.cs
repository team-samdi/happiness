using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

public class OreData : MonoBehaviour
{
    [Serializable]
    private struct DropItem
    {
        public Item _item;
        [Range(0, 100)]
        public float _dropPercent;
    }
    
    [SerializeField]
    private List<DropItem> _dropItems;

    public Item dropItem()
    {
        int target = -1;
        Random rand = new Random();
        
        int num = rand.Next(0, 101);
        float cumulative = 0f;
        for (int i = 0; i < _dropItems.Count; i++)
        {
            cumulative += _dropItems[i]._dropPercent;
            if (num <= cumulative)
            {
                return _dropItems[i]._item;
            }
        }
        return null;
    }
}
