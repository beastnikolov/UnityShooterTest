using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Item : ScriptableObject
{

    //Item
    public string itemName;
    public Sprite itemSprite;
    public float itemSpriteScale;
    public enum itemRarity { COMMON , RARE , LEGENDARY };
    public itemRarity rarityofItem;

    public string itemDescription;
    public float itemWeight;
    public enum itemType { WEAPON , ARMOR, PICKUP, MATERIAL, NONE};
    public itemType typeOfItem;
    public int itemCount;
    public bool isItemDeletable;


   
}
