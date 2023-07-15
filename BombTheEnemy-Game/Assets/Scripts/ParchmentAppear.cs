using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ParchmentAppear : MonoBehaviour
{
    [SerializeField] private Image parchmentImage;
    public string message;
    [Tooltip("The message that will appear when the player is in the trigger")]
    public Transform messageText;
    [Tooltip("The Text transform that will display the message")]
    public AudioSource parchmentSound;


    void OnTriggerEnter(Collider other)
    {
        setParchmentImage(true, other);
    }

    void OnTriggerExit(Collider other)
    {
        setParchmentImage(false, other);
    }

    private void setParchmentImage(bool isEnter, Collider other)
    {
        TextMeshProUGUI text = messageText.GetComponent<TextMeshProUGUI>();
        if(other.gameObject.CompareTag("Player"))
        {
            if(isEnter)
            { 
                parchmentSound.Play();
                text.text = message;
            }
            else
                text.text = "";
        }   
        parchmentImage.enabled = isEnter;
    }
}
