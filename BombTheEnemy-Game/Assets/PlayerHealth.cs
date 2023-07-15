using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    const float MAX_HEALTH = 100f;
    private float currentHealth;
    public Animator animator;
    const int MAX_LIVES = 1;
    public GameObject[] lives;
    public Slider healthBar;

    private int currentLives = 1;
    private const int DEAD_ANIMATION_TIME = 3000;

    private void Start()
    {
        currentHealth = MAX_HEALTH;
        UpdateLivesUI();
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        AudioManager.instance.Play("PlayerDamage");
        animator.SetTrigger("isDamaged");

        if (currentHealth <= 0)
        {
            if (currentLives > 1)
            {
                Debug.Log("Player lost a life --");
                currentLives--;
                currentHealth = MAX_HEALTH;
                UpdateLivesUI();
                UpdateHealthUI();
            }
             else
            {
                Debug.Log("Player died");
                Die();
            }
        }
        else
            UpdateHealthUI();
    }

    public bool IsHealthFull()
    {
        return currentHealth == MAX_HEALTH;
    }

    public void AddLives(int amount)
    {
        currentLives += amount;
        UpdateLivesUI();
    }

    public void Die()
    {
        animator.SetTrigger("isDead");
        AudioManager.instance.Play("PlayerDie");
        GetComponent<Collider>().enabled = false;
        GameManager.Instance().GameOver();
    }
    private void UpdateHealthUI()
    {
        healthBar.value = currentHealth;
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lives.Length; i++)
    
            lives[i].SetActive(i < currentLives);
    }
}
