using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    Vector2 startPos;
    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spikes"))
        {
            PlayerDie();
        }
    }

    void PlayerDie()
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