using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject pickUpObject;
    public GameObject playerRightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pickUp()
    {
        pickUpObject.transform.SetParent(playerRightHand.transform);
        pickUpObject.transform.localScale = new Vector3(1, 1, 1);
    }

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
