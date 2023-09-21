using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.AddForce(new Vector2(2, 0));
        rb.velocity = transform.up * 2;
        if (transform.localPosition.x > 0)
        {
            // sparo verso destra
            //transform.position += new Vector3(transform.position.x * Time.deltaTime * 1, 0, 0);
            rb.velocity = new Vector2(2, 0);
        }
        else
        {
            // sparo verso sinistra
            //transform.position += new Vector3(transform.position.x * Time.deltaTime * -1, 0, 0);
            rb.velocity = new Vector2(-2, 0);
        }
    }
}
