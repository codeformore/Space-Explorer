using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{

    public Transform chamber;
    public GameObject bullet;
    public float bulletCoolDown;
    private float bulletCoolDownTimer;
    private Rigidbody2D rig;

    void Start()
    {

        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletCoolDownTimer <= 0)
        {

            Instantiate(bullet, chamber.position, chamber.rotation).tag = "projectileP";
            bulletCoolDownTimer = bulletCoolDown;

        }

        bulletCoolDownTimer -= Time.deltaTime;

    }

}
