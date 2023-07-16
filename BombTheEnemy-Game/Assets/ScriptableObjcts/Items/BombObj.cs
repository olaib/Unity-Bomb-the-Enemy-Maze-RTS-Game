using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombObj : MonoBehaviour
{
    private const float BOMB_FUSE_TIME = 2f,
                        FORCE = 700f;
    public float countdownTimer = 7f;
    public GameObject explosionEffect;
    public AudioSource explosionSound;
    public float destroyTime = 2f;
    public float radios = 5f;
    private bool isActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownTimer = BOMB_FUSE_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        //if pressed b - activate bomb
        if(Input.GetKeyDown(KeyCode.B))
            isActivate = true;

        if(isActivate)
        {
            countdownTimer -= Time.deltaTime;
        
            // if on ground of tile and countdown timer is less than 0
            if(countdownTimer <= 0)
            {
                Explode();
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collided with " + other.gameObject.name);
        if(other.gameObject.tag == "Player" )
        {
            isActivate = true;
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

            DistructableObject distructable = nearbyObj.GetComponent<DistructableObject>();
            if(distructable)
            {
                distructable.DestroySelf();
            }
        }
        if(explosionSound)
            explosionSound.Play();
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
