using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bomb", menuName = "ScriptableObjects/Bomb")]
public class BombObject : ItemObject
{
    public void Awake()
    {
        type = ItemType.Bomb;
    }
}
