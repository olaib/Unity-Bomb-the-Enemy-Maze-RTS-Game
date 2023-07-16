using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour
{
    public GameObject bombPrefab; // Prefab of the bomb GameObject
    public Transform spawnPoint; // The point where the bomb will be spawned

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(spawnPoint.childCount == 0)
            {
                SpawnBomb();
            }
        }
    }

    private void SpawnBomb()
    {
        // Instantiate the bomb prefab
        GameObject bomb = Instantiate(bombPrefab, spawnPoint.position, Quaternion.identity);

        // Optionally, you can set the box as the parent of the spawned bomb
        // set position to be same of point spawn
        bomb.transform.SetParent(spawnPoint);
    }
}


