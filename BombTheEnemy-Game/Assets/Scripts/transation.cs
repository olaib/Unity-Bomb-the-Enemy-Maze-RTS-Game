using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transation : MonoBehaviour
{
    Animator anim;
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void displayOptions()
    {
        StartGameOptionsPanel.SetActive(true);
        MainOptionsPanel.SetActive(false);
        anim.Play("buttonTweenAnims_on");
    }
    public void displayMainMenu()
    {
        StartGameOptionsPanel.SetActive(false);
        MainOptionsPanel.SetActive(true);
        anim.Play("buttonTweenAnims_off");
    }
}
