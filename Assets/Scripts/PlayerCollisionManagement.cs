using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManagement : MonoBehaviour
{

    public PlayerInventory inventory;

    void Start()
    {

        inventory = GetComponent<PlayerInventory>();

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("item"))
        {
            
            int itemToAdd = other.gameObject.GetComponent<pickUp>().itemToPickUp;
            bool result = inventory.AddItemToInventory(itemToAdd);
            
            if (result)
                Destroy(other.gameObject);

        }

    }

}
