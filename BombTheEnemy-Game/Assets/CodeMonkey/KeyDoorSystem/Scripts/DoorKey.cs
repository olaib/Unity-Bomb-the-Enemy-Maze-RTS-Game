using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.KeyDoorSystemCM {

    
    public class DoorKey : MonoBehaviour {

        [Header("Door Key")]
        [Tooltip("The Key Scriptable Object")]
        public Key key;

        public void DestroySelf() {
            // Destroy this Key
            Destroy(gameObject);
        }

    }

}