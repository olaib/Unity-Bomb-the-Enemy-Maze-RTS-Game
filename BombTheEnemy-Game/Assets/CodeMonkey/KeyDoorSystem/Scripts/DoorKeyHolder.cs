using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.KeyDoorSystemCM {


    public class DoorKeyHolder : MonoBehaviour {

        public event EventHandler OnDoorKeyAdded;
        public event EventHandler OnDoorKeyUsed;

        public List<Key> doorKeyHoldingList = new List<Key>(); 

        void OnTriggerEnter(Collider collider) {
            DoorKey doorKey = collider.GetComponent<DoorKey>();
            if (doorKey != null) {
                doorKeyHoldingList.Add(doorKey.key);
                doorKey.DestroySelf();
                OnDoorKeyAdded?.Invoke(this, EventArgs.Empty);
            }

            DoorLock doorLock = collider.GetComponent<DoorLock>();
            if(doorLock != null && doorKeyHoldingList.Contains(doorLock.key))
            {
                // if(doorLock.isGameSolveRequired())
                // {
                //     GameManager.Instance().PlayMiniGame(doorLock.getSceneName());
                //     return;
                // }
                // Has key! Open door!
                doorLock.OpenDoor();
                if (doorLock.removeKeyOnUse) {
                    doorKeyHoldingList.Remove(doorLock.key);
                }
                OnDoorKeyUsed?.Invoke(this, EventArgs.Empty);
            }
        }

    }

}