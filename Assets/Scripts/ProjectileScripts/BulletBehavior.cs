using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    
    public float lifeTime;
    public float bulletSpeed;
    private Rigidbody2D rig;

    public float damage;

    void Start()
    {
        Destroy(gameObject, lifeTime);
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(transform.up * bulletSpeed);
    }
}
