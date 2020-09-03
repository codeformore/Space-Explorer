using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    
    //Control Variables
    public float maxWeight;
    public float shipWeight;
    public List<Item> inventory = new List<Item>();

    //Current Variables
    public float currentWeight {get; private set;}

    //Other Variables
    public GameObject dropItemPrefab;
    private Rigidbody2D rig;

    //Events
    public delegate void InventoryChangeHandeler();
    public static event InventoryChangeHandeler InventoryChange;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();
        rig.mass = shipWeight;

    }

    //Event Functions
    private void InventoryChanged() 
    {

        if (InventoryChange != null)
            InventoryChange();

    }

    //Weight Capacity Functions
    public void ChangeWeightCapacity(float changeInInventoryCapacity)
    {

        maxWeight += changeInInventoryCapacity;

    }
    public void SetWeightCapacity(float newWeightCapacity)
    {

        maxWeight = newWeightCapacity;

    }

    //Current Weight Functions
    private void AddWeight(float weight)
    {

        currentWeight += weight;
        rig.mass += weight;

    }
    private void RemoveWeight(float weight)
    {

        currentWeight -= weight;
        rig.mass -= weight;

    }
    private void UpdateWeight()
    {

        float weightToAdd = 0;
        foreach (Item item in inventory)
        {

            weightToAdd += item.weight;

        }
        rig.mass = weightToAdd + shipWeight;
        currentWeight = weightToAdd;

    }

    //Inventory Management Functions
    public bool AddItemToInventory(int itemIDToAdd)
    {

        Item itemToAdd = ItemLibrary.GetItem(itemIDToAdd);

        if (currentWeight + itemToAdd.weight < maxWeight)
        {
            
            inventory.Add(itemToAdd);
            UpdateWeight();
            InventoryChanged();
            return true;

        }
        else
        {

            InventoryChanged();
            return false;

        }

    }
    public bool DropFromInventoryString(string itemToRemove, int amountToRemove)
    {

        int counter = 0;

        for (int i = 0; counter < amountToRemove; i++)
        {

            if (inventory[i].name == itemToRemove)
            {

                GameObject drop = Instantiate(dropItemPrefab, transform);
                drop.GetComponent<pickUp>().itemToPickUp = inventory[i].id;
                UpdateWeight();
                counter++;

            }

            if (inventory.Count - 1 == i)
            {

                InventoryChanged();
                return false;

            } 

        }

        InventoryChanged();
        return true;

    }
    public bool DropFromInventoryID(int id, int amountToRemove)
    {

        int counter = 0;

        for (int i = 0; counter < amountToRemove; i++)
        {

            if (inventory[i].id == id)
            {

                GameObject drop = Instantiate(dropItemPrefab, transform);
                drop.GetComponent<pickUp>().itemToPickUp = inventory[i].id;
                UpdateWeight();
                counter++;

            }

            if (inventory.Count - 1 == i)
            {

                InventoryChanged();
                return false;

            } 

        }
        
        InventoryChanged();
        return true;

    }

}
