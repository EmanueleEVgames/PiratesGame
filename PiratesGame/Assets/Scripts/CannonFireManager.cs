using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireManager : MonoBehaviour
{
    DateTime lastTimeFire;
    Animator anim;
    int numOfSecDelay = 2;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeFire=DateTime.Now;
        anim=GetComponent<Animator>();
        anim.SetBool("FireCannonBall", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now>=lastTimeFire.AddSeconds(numOfSecDelay))
        {
            lastTimeFire = DateTime.Now;
            anim.SetBool("FireCannonBall", true);
        }
        if (DateTime.Now >= lastTimeFire.AddSeconds(0.5))
            anim.SetBool("FireCannonBall", false);
    }
}
