using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed;
    private Rigidbody2D rig;
    private PlayerVitals vitals;

    void Start() 
    {

        rig = GetComponent<Rigidbody2D>();
        vitals = GetComponent<PlayerVitals>();

    }

    void FixedUpdate()
    {

        //Get Mouse Position and Make Player Look at it
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.up = mousePos - transform.position;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        if (vitals.Fuel > 0) 
        {
            //Vertical Movement
            float vertInput = Input.GetAxis("Vertical");
            rig.AddForce(transform.up * speed * vertInput);
            vitals.UseFuel(Mathf.Abs((speed * vertInput) * rig.velocity.magnitude * Time.fixedDeltaTime));

            //Horizontal Movement
            float horiInput = Input.GetAxis("Horizontal");
            rig.AddForce(transform.right * speed * horiInput);
            vitals.UseFuel(Mathf.Abs((speed * horiInput) * rig.velocity.magnitude * Time.fixedDeltaTime));
        }

        else
        {

            Debug.LogAssertion("Out of Fuel");

        }

    }

}
