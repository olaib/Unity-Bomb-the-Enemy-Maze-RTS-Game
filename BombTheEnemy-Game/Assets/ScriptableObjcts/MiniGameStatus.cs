using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MiniGameStatus", menuName = "ScriptableObjects/MiniGameStatus")]
public class MiniGameStatus : ScriptableObject
{
    public enum MiniGameCompletionStatus
    {
        InProgress,
        Completed
    }

    [SerializeField]
    private string miniGameSceneName;
    [Tooltip("The name of the mini game scene")]


    public MiniGameCompletionStatus completionStatus{get; set;}

    public void Start()
    {
        completionStatus = MiniGameCompletionStatus.InProgress;
    }

    public void SetGameCompleted()
    {
        completionStatus = MiniGameCompletionStatus.Completed;
    }

    public bool CheckIfCompleted()
    {
        return completionStatus == MiniGameCompletionStatus.Completed;
    }

    public string GetMiniGameSceneName()
    {
        return miniGameSceneName;
    }
}
