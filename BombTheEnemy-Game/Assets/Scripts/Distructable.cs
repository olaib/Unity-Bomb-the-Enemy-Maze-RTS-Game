using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distructable : MonoBehaviour
{
    private const float BOMB_FUSE_TIME = 5f,
                        FORCE = 700f;
    public float countdownTimer = 7f;
    public GameObject explosionEffect;
    // public AudioSource explosionSound;
    public float destroyTime = 5f;
    public float radios = 5f;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = BOMB_FUSE_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer -= Time.deltaTime;
        // if on ground of tile and countdown timer is less than 0
        if(countdownTimer <= 0)
        {
            Explode();
        }
    }

    private void Explode()
    {
        // Get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radios);
        // explode nearby objects
        foreach(Collider nearbyObj in colliders){
            Rigidbody rb = nearbyObj.GetComponent<Rigidbody>();
            if(rb)
            {
                rb.AddExplosionForce(FORCE, transform.position, radios);
            }
        }

        // explosionSound.Play();
        // create explosion effect at bomb position
        GameObject explosionEffectObj = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        explosionEffectObj.SetActive(true);
        explosionEffectObj.GetComponent<ParticleSystem>().Play();
        
        // Destroy the explosion effect after a delay
        Destroy(explosionEffectObj, destroyTime);

        // Destroy the bomb object
        Destroy(gameObject);
    }
}
