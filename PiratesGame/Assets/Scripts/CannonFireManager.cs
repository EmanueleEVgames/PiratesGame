using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFireManager : MonoBehaviour
{
    DateTime lastTimeFire;
    Animator anim;

    [SerializeField]
    int delayBetweenShoots = 2;

    Animator animFireEffect;

    [SerializeField]
    Rigidbody2D cannonBall;
    [SerializeField]
    GameObject cannonBall2;

    //UnityEngine.Object bullet;

    [SerializeField]
    Transform cannonBallStartPosition;
    public float cannonBallSpeed = 4;

    

    // Start is called before the first frame update
    void Start()
    {
        lastTimeFire = DateTime.Now;
        anim = GetComponent<Animator>();
        anim.SetBool("FireCannonBall", false);

        //bullet = Resources.Load("CannonBall");

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
        if (DateTime.Now >= lastTimeFire.AddSeconds(delayBetweenShoots))
        {
            lastTimeFire = DateTime.Now;
            Instantiate(cannonBall, cannonBallStartPosition.position, Quaternion.identity);
            anim.SetBool("FireCannonBall", true);
            //animFireEffect.SetBool("CanFire", true);

            //GameObject bullets = (GameObject)Instantiate(bullet);
            //bullets.transform.position = new Vector3(cannonBallStartPosition.position.x, cannonBallStartPosition.position.y, cannonBallStartPosition.position.z);

            //var projectile = Instantiate(cannonBall, new Vector3(cannonBallStartPosition.position.x, cannonBallStartPosition.position.y, transform.position.z), Quaternion.identity);
            Instantiate(cannonBall, cannonBallStartPosition.position, Quaternion.identity);
            //projectile.GetComponent<Rigidbody2D>().velocity = transform.up * cannonBallSpeed;
        }
        if (DateTime.Now >= lastTimeFire.AddSeconds(0.5))
        {
            anim.SetBool("FireCannonBall", false);
            animFireEffect.SetBool("CanFire", false);
        }


    }
}
