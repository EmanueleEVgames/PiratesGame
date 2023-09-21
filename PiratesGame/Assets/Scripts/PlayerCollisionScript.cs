using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField] GameControllerScript gameControllerScript;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            gameControllerScript.PlayerDie();
        }
        if (collision.CompareTag("KeyDoor"))
        {
            gameControllerScript.KeyToPlayer(true, collision);

            //PlayerHasKey = true;
            //Animator animator = collision.GetComponent<Animator>();
            //animator.SetBool("KeyCaptured", true);
            //Destroy(collision.gameObject, 0.3f);
        }

        if (collision.CompareTag("Door"))
        {
            gameControllerScript.CheckForKey(collision);
            //if (PlayerHasKey)
            //{
            //    Animator animator = collision.GetComponent<Animator>();
            //    animator.SetBool("PlayerHasKey", true);
            //}

        }
    }


}
