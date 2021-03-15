using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPickUpManager : MonoBehaviour
{

    public Item pickupItem;
    public TextMeshProUGUI itemText;
    // Start is called before the first frame update
    void Start()
    {
        if (pickupItem != null)
        {
            GetComponent<SpriteRenderer>().sprite = pickupItem.itemSprite;
            itemText.text = pickupItem.itemName;
            transform.localScale = new Vector2(pickupItem.itemSpriteScale, pickupItem.itemSpriteScale);
        }
    }

    public void updateItemSprite()
    {
        GetComponent<SpriteRenderer>().sprite = pickupItem.itemSprite;
        transform.localScale = new Vector2(pickupItem.itemSpriteScale, pickupItem.itemSpriteScale);
        itemText.text = pickupItem.itemName;
    }

    public Item getPickedItem()
    {
        return pickupItem;
    }

}
