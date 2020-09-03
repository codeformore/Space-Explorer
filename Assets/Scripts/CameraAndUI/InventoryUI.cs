using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public Dictionary<Item, int> UIInventory = new Dictionary<Item, int>();
    public GameObject[] displayObjects;
    public GameObject template;
    public GameObject contentPane;
    public GameObject inventoryUI;
    public GameObject inGameUI;
    public PlayerInventory playerInventory;

    void Awake()
    {

        PlayerInventory.InventoryChange += UpdateInventoryList;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
            ToggleVisibility();

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
            rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, posY);
            counter++;

        }

    }

    void ToggleVisibility()
    {

        inventoryUI.SetActive(!inventoryUI.activeSelf);
        inGameUI.SetActive(!inGameUI.activeSelf);

    }

}
