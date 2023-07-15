using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CodeMonkey.KeyDoorSystemCM {

    public class DoorLock : MonoBehaviour {
        [Header("Open Door Sound")]
        [Tooltip("Sound to play when the Door is Opened")]
        public AudioSource openSound;

        [Header("Door Lock")]
        [Tooltip("The Key that opens this Door")]
        public Key key;
        [Tooltip("Remove the Key from the Holder after using it to open this Door?")]
        public bool removeKeyOnUse;
        [Tooltip("MiniGame")]

        public MiniGameScene miniGameScene;

        private bool isMiniGameSolved = false;
        public bool requiresMiniGame = false;

        Animator m_Animator;

        void Awake() {
            // Cache Animator Component
            m_Animator = GetComponent<Animator>();
        }

        public void OpenDoor() {
            openSound.Play();
            // Play Open Door Animation
            m_Animator.SetTrigger("Open");
        }

        public void CloseDoor() {
            // Play Close Door Animation
            m_Animator.SetTrigger("Close");
        }

        public void OnTrigerEnter2D(Collider2D collision) {
            Debug.Log("OnTrigerEnter2D");
            if(collision.gameObject.tag == "Player")
                OpenDoor();

        }
        public bool isGameSolveRequired()
        {
            return requiresMiniGame && !isMiniGameSolved;
        }

        public MiniGameScene getSceneName()
        {
            return miniGameScene;
        }
    }
}