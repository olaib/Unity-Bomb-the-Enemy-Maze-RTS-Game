// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;

// public class enemy : MonoBehaviour
// {
//     public NavMeshAgent agent;
//     public Transform player;
//      void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player").transform;
//         if (player == null)
//         {
//             Debug.LogError("Player object not found!");
//         }
//     }

//     void Update()
//     {
//         if (player == null)
//         {
//             return;
//         }
//         agent.SetDestination(player.position);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Transform player;
    private float dist;
    public float moveSpeed;
    public float rotationSpeed;
    public float minDist;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        dist = Vector3.Distance(transform.position, player.position);
        if (dist <= minDist)
        {
            // absolute value of the vector
            Vector3 direction = transform.position - player.position; // Reverse the direction vector
            direction.y = 0;
            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            if (dist > 1.5f)
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                Debug.Log("Attack");
            }
        }
    }
}
