using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Speard")
        {
            GameManager.Instance().GameOver();
            Destroy(gameObject);
        }
    }
}
