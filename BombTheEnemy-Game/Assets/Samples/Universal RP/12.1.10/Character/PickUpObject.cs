using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* pick up object - attach to player
*/
public class PickUpObject : MonoBehaviour
{
    public GameObject pickUpObject;
    public GameObject playerRightHand;
 
    /*
        * Update THE OBJECT 
        * this method is called every frame and is used to update the state of the game
        */
    public void pickUp()
    {
        pickUpObject.transform.SetParent(playerRightHand.transform);
        pickUpObject.transform.localScale = new Vector3(1, 1, 1);
    }
    /*
        * collision detection
        @param other - the other object
    */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        if (other.gameObject.CompareTag("PickableObject"))
        {
            Debug.Log("Pickable Object");
            pickUpObject = other.gameObject;
        }
    }
}
