using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour
{
    
    //Variables
    private static Dictionary<int, Item> itemDictionary = new Dictionary<int, Item>();

    //Load Item Library
    void Awake()
    {

        Item[] itemEntries = Resources.LoadAll<Item>("Items/");

        foreach (Item item in itemEntries)
        {

            if (itemDictionary.ContainsKey(item.id))
            {

                Debug.LogError("Two Items have the same ID!" + item.itemName + " has the same ID as " + itemDictionary[item.id].itemName);

            }
            else
            {

                itemDictionary.Add(item.id, item);

            }

        }

        Debug.Log("Items Loaded! Listing Items");
        foreach (KeyValuePair<int, Item> entry in itemDictionary)
        {

            Debug.Log(entry.Value.itemName);

        }

    }

    static public Item GetItem(int id)
    {

        Item getItem;
        if (itemDictionary.TryGetValue(id, out getItem))
        {

            return getItem;

        }
        else
        {

            Debug.LogError("Could not find item with id, " + id);
            return null;

        }

    }

}
