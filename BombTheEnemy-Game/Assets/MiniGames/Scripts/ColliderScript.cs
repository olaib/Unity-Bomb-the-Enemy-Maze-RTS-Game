using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    public MiniGameStatus MiniGameStatus;
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            isTriggered = true;
            GameManager.Instance().PlayMiniGame(MiniGameScene.BullsCowsGame);
        }
    }
}
