using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControllerScript : MonoBehaviour
{
    [SerializeField]
    Transform posA, posB;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 targetPos;

    [SerializeField]
    Animator animator;

    bool startMoving;

    private void Start()
    {
        targetPos = posB.position;

        startMoving = false;
    }


    private void Update()
    {
        if (startMoving)
        {
            if (Vector2.Distance(transform.position, posA.position) < 0.05f)
            {
                targetPos = posB.position;

            }
            if (Vector2.Distance(transform.position, posB.position) < 0.05f)
            {
                targetPos = posA.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;

            animator.SetBool("PlayerOnBoard", true);

            startMoving = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    collision.transform.parent = null;
        //}
    }
}
