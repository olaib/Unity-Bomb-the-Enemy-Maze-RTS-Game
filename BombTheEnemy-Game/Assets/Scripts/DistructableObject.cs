using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DistructableObject : MonoBehaviour
{
    public void DestroySelf()
    {
        if (gameObject.CompareTag("Player"))
        {
            GameManager.Instance().GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}