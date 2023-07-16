using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    This class for dragon
    updating the Hp (health bar)
*/
public class Dragon : MonoBehaviour
{
    private int HP = 100;
    public Animator animator;

    public Slider healthBarSlider;

    void Update(){
        healthBarSlider.value = HP;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        // die
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            AudioManager.instance.Play("DragonDeath");
            Destroy(gameObject, 5f);
        }
        // hit
        else {
            AudioManager.instance.Play("DragonDamage");
            animator.SetTrigger("damage");
        }
    }

}
