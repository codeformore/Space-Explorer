using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    
    //Variables
    public int itemToPickUp;
    public float lifeTime;
    public Vector2 range;

    //Components
    private Rigidbody2D rig;

    void Start()
    {

        //Set Sprite of Pickup
        GetComponent<SpriteRenderer>().sprite = ItemLibrary.GetItem(itemToPickUp).icon;
        
        //Add Random Direction and Magantude Force
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Random.Range(range.x, range.y) * new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
        
        //Set Lifetime To Destroy
        Destroy(gameObject, lifeTime);

    }

}
