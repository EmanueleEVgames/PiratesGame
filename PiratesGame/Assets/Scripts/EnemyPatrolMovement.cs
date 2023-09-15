using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField]
    Transform posA, posB;
    [SerializeField]
    float speed;
    [SerializeField]
    Vector3 targetPos;

    Rigidbody2D rigidbody2D;
    Animator anim;
    SpriteRenderer _spriteRenderer;

    enum EnemyMovementState { Idle, Running, Jumping, Falling }

    private EnemyMovementState movementState;

    private void Start()
    {
        targetPos = posB.position;
        rigidbody2D=GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
            _spriteRenderer.flipX = true;

        }
        if (Vector2.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
            _spriteRenderer.flipX = false;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        UpdateAnimation(true, rigidbody2D.velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    collision.transform.parent = this.transform;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.CompareTag("Player"))
        //{
        //    collision.transform.parent = null;
        //}
    }

    void UpdateAnimation(bool isGrounded, Vector2 vel)
    {
        if (isGrounded)
            //anim.SetBool("IsGrounded", true);
            movementState = EnemyMovementState.Idle;
        //else
        //    anim.SetBool("IsGrounded", false);
        if (vel.x != 0)
        {
            //anim.SetBool("IsRunning", true);
            movementState = EnemyMovementState.Running;

            //if (vel.x > 0)
            //    _spriteRenderer.flipX = false;
            //else
            //    _spriteRenderer.flipX = true;
        }
        else
            movementState = EnemyMovementState.Idle;
        //anim.SetBool("IsRunning", false);

        //if (rigidbody2D.velocity.y > 0.1f)
        //    movementState = EnemyMovementState.Jumping;
        //if (rigidbody2D.velocity.y < -0.1f)
        //    movementState = EnemyMovementState.Falling;

        Debug.Log("state: " + movementState);
        anim.SetInteger("state", (int)movementState);

    }



}
