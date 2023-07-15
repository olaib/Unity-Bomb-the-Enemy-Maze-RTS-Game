using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public const float SPEED = 5f;
    public const float BOMB_RANGE = 5f;
    // public GameObject bombPrefab;

    private Rigidbody rb;
    [Tooltip("Holding the Rigidbody component of the enemy, This will enable physics calculations for the enemy.")]

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        Debug.Log(" movement");
        StartCoroutine(RandomMovement());
    }

    void Update()
    {
        // // Check if player is within bomb range
        // RaycastHit hit;
        // if (Physics.Raycast(transform.position, Vector3.forward, out hit, BOMB_RANGE))
        // {
        //     // If player is within range, drop bomb
        //     Instantiate(bombPrefab, transform.position, Quaternion.identity);
        // }
    }

    IEnumerator RandomMovement()
    {
        Debug.Log("in movement");

        while (true)
        {
            Debug.Log("doing a move");
            // Generate a random movement direction
            float x = Random.Range(-1f, 1f);
            float y = Random.Range(-1f, 1f);
            Vector3 direction = new Vector3(x, y, 0f).normalized;

            // Add some variation to the movement direction
            float perlinNoise = Mathf.PerlinNoise(Time.time, Time.time);
            direction += new Vector3(perlinNoise, perlinNoise, 0f);

            // Move enemy in the direction
            rb.velocity = direction * SPEED;

            // Wait for a few seconds before generating a new movement direction
            yield return new WaitForSeconds(2f);
        }
    }
}
