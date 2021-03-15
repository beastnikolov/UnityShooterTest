using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryTesting : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Item testItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInventory.deleteItem(testItem);
           // playerInventory.doesItemExist(testItem);
           // playerInventory.inventoryDebug();
        }
    }
}
