using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningScript : MonoBehaviour
{
   public AudioSource winningAudioSource;
   public float timer = 3f;
//    public Transform winningText;

    void Start()
    {
        winningAudioSource = GetComponent<AudioSource>();
    }

    // check if collide with player then play audio and display text
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter winning");
        if(collision.gameObject.tag == "Player")
        {
            //pause game
            Debug.Log("You Win!");
            Time.timeScale = 0;
            winningAudioSource.Play();
            StartCoroutine("WaitForSec", timer);
        }
    }
}
