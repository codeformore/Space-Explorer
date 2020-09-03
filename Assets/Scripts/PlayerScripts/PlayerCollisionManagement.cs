using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManagement : MonoBehaviour
{

    private PlayerInventory inventory;
    private Rigidbody2D rig;
    private PlayerVitals vitals;

    void Start()
    {

        inventory = GetComponent<PlayerInventory>();
        rig = GetComponent<Rigidbody2D>();
        vitals = GetComponent<PlayerVitals>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("projectile"))
        {

            vitals.TakeDamage(other.GetComponent<BulletBehavior>().damage);
            Destroy(other.gameObject);

        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("object"))
        {

            vitals.TakeDamage(rig.velocity.magnitude);

        }
        
        if (other.gameObject.CompareTag("item"))
        {
            
            int itemToAdd = other.gameObject.GetComponent<pickUp>().itemToPickUp;
            bool result = inventory.AddItemToInventory(itemToAdd);
            
            if (result)
                Destroy(other.gameObject);

        }

    }

}
