using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 20;
    public float destroyTime = 10;
    
    private void Start()
    {
        // arrow destroyed after 10 sec
        Destroy(gameObject, destroyTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Arrow hit: " + other.tag);
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Dragon")
        {
            Debug.Log("stuck");
            // stuck on the dragon body
            transform.SetParent(other.transform);
            // start damage (health bar -= damage)
            other.GetComponent<Dragon>().TakeDamage(damage);
        }
    }
}
