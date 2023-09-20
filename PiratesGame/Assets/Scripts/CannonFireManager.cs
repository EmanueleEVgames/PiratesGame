using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireManager : MonoBehaviour
{
    DateTime lastTimeFire;
    Animator anim;
    int numOfSecDelay = 2;

    Animator animFireEffect;

    // Start is called before the first frame update
    void Start()
    {
        lastTimeFire = DateTime.Now;
        anim = GetComponent<Animator>();
        anim.SetBool("FireCannonBall", false);

        Transform effect = GameObject.Find("FireEffect").transform;
        foreach (Transform thisChild in effect)
        {
            animFireEffect = thisChild.GetComponent<Animator>();
        }
        //    animFireEffect = GetComponentInChildren<Animator>();

        animFireEffect.SetBool("CanFire", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now >= lastTimeFire.AddSeconds(numOfSecDelay))
        {
            lastTimeFire = DateTime.Now;
            anim.SetBool("FireCannonBall", true);
            animFireEffect.SetBool("CanFire", true);
        }
        if (DateTime.Now >= lastTimeFire.AddSeconds(0.5))
        {
            anim.SetBool("FireCannonBall", false);
            animFireEffect.SetBool("CanFire", false);
        }


    }
}
