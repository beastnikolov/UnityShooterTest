using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{

    public Transform targetTransform;
    public GameObject itemDisplayPrefab;
    // Start is called before the first frame update
    void Start()
    {
        instantiateItems(GameObject.Find("Player").GetComponent<PlayerInventory>().getInventoryItemList());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void instantiateItems(List<Item> playerInventoryList)
    {
        GameObject[] itemEntries = GameObject.FindGameObjectsWithTag("InventoryEntry");
        foreach (GameObject itemEntry in itemEntries)
        {
            Destroy(itemEntry);
        }
        foreach (Item item in playerInventoryList)
        {
            GameObject itemDisplay = Instantiate(itemDisplayPrefab);
            itemDisplay.transform.SetParent(targetTransform, false);
            itemDisplay.GetComponent<ItemDisplay>().updateItemEntry(item);
        }
    }
}
