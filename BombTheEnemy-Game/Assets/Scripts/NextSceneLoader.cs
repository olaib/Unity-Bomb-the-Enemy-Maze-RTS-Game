using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class stopAudio : MonoBehaviour
{
    public AudioSource audioSource;
    [Tooltip("The intro audio source to stop")]

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void NextScene()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
}
