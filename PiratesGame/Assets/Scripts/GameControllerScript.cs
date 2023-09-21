using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D rigidbody2D;

    bool PlayerHasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Spikes"))
    //    {
    //        PlayerDie();
    //    }
    //    if (collision.CompareTag("KeyDoor"))
    //    {
    //        PlayerHasKey = true;

    //        Animator animator = collision.GetComponent<Animator>();
    //        animator.SetBool("KeyCaptured", true);
    //        Destroy(collision.gameObject, 0.3f);
    //    }

    //    if (collision.CompareTag("Door"))
    //    {
    //        if (PlayerHasKey)
    //        {
    //            Animator animator = collision.GetComponent<Animator>();
    //            animator.SetBool("PlayerHasKey", true);
    //        }

    //    }
    //}

    public void KeyToPlayer(bool hasKey,Collider2D collision)
    {
        if (hasKey)
        {
            PlayerHasKey = true;
            Animator animator = collision.GetComponent<Animator>();
            animator.SetBool("KeyCaptured", true);
            Destroy(collision.gameObject, 0.3f);
        }
    }

    public void CheckForKey(Collider2D collision)
    {
        if (PlayerHasKey)
        {
            Animator animator = collision.GetComponent<Animator>();
            animator.SetBool("PlayerHasKey", true);
        }
    }

    public void PlayerDie()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        rigidbody2D.simulated = false;
        rigidbody2D.velocity = new Vector2(0, 0);
        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(duration);
        transform.position = startPos;
        transform.localScale = Vector3.one;
        rigidbody2D.simulated = true;

    }
}
