using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{    
    GameControllerScript gameControllerScript;

    [SerializeField]
    Transform respawnPoint;
    Collider2D collider;
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        gameControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<GameControllerScript>();
        anim=GetComponent<Animator>();
        collider=GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameControllerScript.UpdateCheckPoint(respawnPoint.position);
            anim.SetTrigger("Spin");
            collider.enabled = false;

        }
    }
}
