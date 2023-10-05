using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviourScript : MonoBehaviour
{
    [SerializeField]
    float speed = 0.3f; // Adjust the speed in the Inspector
    //public LayerMask collisionLayer; // Specify which layers should trigger destruction
    private void Update()
    {
        //Move the object to the left 
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with a collider on the specified layer
        //if (collisionLayer.ContainsLayer(other.gameObject.layer))
        if (other.CompareTag("GarbageCollect"))
        {
            // Destroy the object when it hits a collider on the specified layer
            Destroy(gameObject);
        }
    }


}
