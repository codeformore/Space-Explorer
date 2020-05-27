using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{

    public Transform chamber;
    public GameObject bullet;
    public float bulletCoolDown;
    private float bulletCoolDownTimer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletCoolDownTimer <= 0)
        {

            Instantiate(bullet, chamber.position, chamber.rotation);
            bulletCoolDownTimer = bulletCoolDown;

        }

        bulletCoolDownTimer -= Time.deltaTime;

    }

}
