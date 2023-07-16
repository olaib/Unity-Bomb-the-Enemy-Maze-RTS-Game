using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour
{
    private Animator animator;
    bool isOpen = false;
    bool isAnimating = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
    }
    private IEnumerator PlayAnimationTrigger()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            if (!isOpen)
            {
                animator.SetTrigger("open");
                isOpen = true;
            }
            else
            {
                animator.SetTrigger("close");
                isOpen = false;
            }
            yield return new WaitForSeconds(1.5f);
            isAnimating = false;
        }
    }

    public void OnTrigerEnter2D(Collider2D collision) {
        Debug.Log("OnCollisionEnter");
        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("key pressed");
            StartCoroutine(PlayAnimationTrigger());
        }
    }
}

