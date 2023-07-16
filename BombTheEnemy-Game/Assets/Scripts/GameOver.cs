using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject animatiedObject;

    public void CancelAnimation()
    {
        animatiedObject.GetComponent<Animator>().enabled = false;
    }

    public void Update()
    {
        //enter key - reload level
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.Instance().ReloadLevel();
        }
    }
}
