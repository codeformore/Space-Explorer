using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    private Rigidbody2D rig;

    void Start() 
    {

        rig = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {

        //Get Mouse Position and Make Player Look at it
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.up = mousePos - transform.position;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        //Vertical Movement
        float vertInput = Input.GetAxis("Vertical");
        rig.AddForce(transform.up * speed * vertInput);

        //Horizontal Movement
        float horiInput = Input.GetAxis("Horizontal");
        rig.AddForce(transform.right * speed * horiInput);

    }

}
