using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Dictionary<Item, int> UIInventory = new Dictionary<Item, int>();
    public GameObject[] displayObjects;
    public GameObject template;
    public GameObject contentPane;
    public PlayerInventory playerInventory;

    void Awake()
    {

        PlayerInventory.InventoryChange += UpdateInventoryList;

    }

    //Updates the List when the inventory changes
    void UpdateInventoryList()
    {

        UIInventory.Clear();

        foreach(Item item in playerInventory.inventory)
        {

            if (UIInventory.ContainsKey(item))
            {

                UIInventory[item]++;

            }

            else
            {

                UIInventory.Add(item, 1);

            }

        }

        DisplayInventory();

    }

    /*void GenerateInventory()
    {

        displayObjects = new GameObject[UIInventory.Count];

        int counter = 0;
        foreach (KeyValuePair<Item, int> keyValue in UIInventory)
        {

            displayObjects[counter] = new GameObject();
            InventoryItem displaySettings = displayObjects[counter].GetComponent<InventoryItem>();

            displaySettings.SetDisplay(keyValue.Key, keyValue.Value * keyValue.Key.weight);

            counter++;

        }

        DisplayInventory();

    }*/

    void DisplayInventory()
    {

        foreach (Transform child in contentPane.transform)
        {

            Destroy(child.gameObject);

        }

        int counter = 0;
        foreach (KeyValuePair<Item, int> keyValue in UIInventory)
        {

            GameObject newUIItem = Instantiate(template, contentPane.transform);
            InventoryItem invItem = newUIItem.GetComponent<InventoryItem>();
            RectTransform rect = newUIItem.GetComponent<RectTransform>();

            invItem.SetDisplay(keyValue.Key, keyValue.Value * keyValue.Key.weight);
            int posY = -(50 + (60 * counter));
            Debug.Log(posY);
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, posY);
            Debug.Log(counter + " " + rect.anchoredPosition.y);
            counter++;

        }

        /*
        foreach (Transform child in contentPane.transform) 
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < displayObjects.Length; i++)
        {
            
            RectTransform rect = displayObjects[i].GetComponent<RectTransform>(); 
            rect.anchoredPosition.Set(rect.anchoredPosition.x, -50 - (60 * i));
            Instantiate(displayObjects[i], contentPane.transform);

        }
        */

    }

}
