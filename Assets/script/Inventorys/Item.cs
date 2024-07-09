using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public AudioSource pickSound;
}
