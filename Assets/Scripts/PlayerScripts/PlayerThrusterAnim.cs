using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrusterAnim : MonoBehaviour
{
    
    private Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();

    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            anim.SetBool("movingForward", true);
        else
            anim.SetBool("movingForward", false);

    }

}
