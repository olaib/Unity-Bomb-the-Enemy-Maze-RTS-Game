using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* arrow class - attach to arrow prefab
*/
public class Arrow : MonoBehaviour
{
    public int damage = 20;
    public float destroyTime = 10;
    
    private void Start()
    {
        // arrow destroyed after 10 sec
        Destroy(gameObject, destroyTime);
    }
    /*
        * collision detection
        @param other - the other object
        * this method is called when the arrow collides with another object
        and destroys the arrow then decreases the health of the dragon
    */
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Arrow hit: " + other.tag);
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Dragon")
        {
            // stuck on the dragon body
            transform.SetParent(other.transform);
            // start damage (health bar -= damage)
            other.GetComponent<Dragon>().TakeDamage(damage);
        }
    }
}
