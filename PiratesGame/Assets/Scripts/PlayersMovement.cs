using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private LayerMask groundLayerMask;
    Vector2 velocity;
    public float distanceToGround = 0;
    private float extraHeightCheck = .1f;
    Rigidbody2D _rigidbody2d;
    BoxCollider2D _boxCollider2d;
    Animator anim;
    SpriteRenderer _spriteRenderer;
    //variables
    //public float PlayersMovementSPeed; //this is players movement speed.
    //private float _playersMovementDirection = 0; //this will give the direction of the players movement.
    //private PlayerControl _inputActionReference; // reference of the generated c# script form the input action
    //private Rigidbody2D _playersRigidBody; //reference of the players rigid body.


    enum PlayerMovementState { Idle, Running, Jumping, Falling }

    private PlayerMovementState movementState;

    private void Start()
    {
        //Getting the reference of the players rigid body.
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _boxCollider2d = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //_inputActionReference = new PlayerControl();
        ////enabling the Input actions
        //_inputActionReference.Enable();
        ////reading the values of the player movement direction for the players movement.
        //_inputActionReference.Player.Move.performed += moving =>
        //{
        //    _playersMovementDirection = moving.ReadValue<float>();
        //};
    }


    private void Update()
    {
        velocity = new Vector2(Input.GetAxis("Horizontal") * speed, _rigidbody2d.velocity.y);
        ////Moving player using player rigid body.
        //_playersRigidBody.velocity =
        //    new Vector2(_playersMovementDirection * PlayersMovementSPeed, _playersRigidBody.velocity.y);

        bool IsGrounded = Is_Grounded();
        if (IsGrounded && Input.GetKeyDown(KeyCode.Space))
            velocity += new Vector2(0, jumpForce);

        _rigidbody2d.velocity = velocity;

        UpdateAnimation(IsGrounded, velocity);

        //if (IsGrounded)
        //    anim.SetBool("IsGrounded", true);
        //else
        //    anim.SetBool("IsGrounded", false);
        //if (velocity.x != 0)
        //            anim.SetBool("IsRunning", true);
        //else
        //    anim.SetBool("IsRunning", false);

    }

    void UpdateAnimation(bool isGrounded, Vector2 vel)
    {
        if (isGrounded)
            //anim.SetBool("IsGrounded", true);
            movementState = PlayerMovementState.Idle;
        //else
        //    anim.SetBool("IsGrounded", false);
        if (vel.x != 0)
        {
            //anim.SetBool("IsRunning", true);
            movementState = PlayerMovementState.Running;

            if (vel.x > 0)
                _spriteRenderer.flipX = false;
            else
                _spriteRenderer.flipX = true;
        }
        else
            movementState = PlayerMovementState.Idle;
        //anim.SetBool("IsRunning", false);
        
        if (_rigidbody2d.velocity.y > 0.1f)
            movementState = PlayerMovementState.Jumping;
        if (_rigidbody2d.velocity.y < -0.1f)
            movementState = PlayerMovementState.Falling;

        Debug.Log("STATO: " + movementState);
        anim.SetInteger("state", (int)movementState);

    }

    bool Is_Grounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(_boxCollider2d.bounds.center,
            Vector2.down, _boxCollider2d.bounds.extents.y + extraHeightCheck, groundLayerMask);

        Color rayColor;

        if (raycastHit2D.collider != null)
            rayColor = Color.green;
        else
            rayColor = Color.red;

        Debug.DrawRay(_boxCollider2d.bounds.center,
            Vector3.down * (_boxCollider2d.bounds.extents.y + extraHeightCheck), rayColor, groundLayerMask);

        //Debug.Log("A TERRA? " + raycastHit2D.collider != null);
        return raycastHit2D.collider != null;


        //Vector3 raycastOrigin = _boxCollider2d.bounds.center;

        //RaycastHit2D raycastHit2D = Physics2D.BoxCast(raycastOrigin, _boxCollider2d.bounds.size, 0, Vector2.down,
        //    extraHeightCheck, groundLayerMask);

        //Color rayColor;

        //if (raycastHit2D.collider != null)
        //{
        //    rayColor = Color.green;
        //}
        //else
        //{
        //    rayColor = Color.red;
        //}

        //distanceToGround = raycastHit2D.distance;

        //Debug.DrawRay(raycastOrigin, Vector3.down * (_boxCollider2d.bounds.extents.y + extraHeightCheck), rayColor, groundLayerMask);
        //return raycastHit2D.collider != null;

    }
}
