using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* Player Pickup - Pick up and throw objects ,attach to player
*/
public class PlayerPickup : MonoBehaviour
{
    // ======================================== members ========================================
    public Transform objTransform,
     playerTransform;
    public bool interactable, pickedup;
    public float throwAmount;

    // private float desiredHeight = 1.5f; // Adjust the desiredHeight value as needed
    private float throwForce = 10f; // Adjust the throwForce value as needed
    // hashset to track picked up objects
    private HashSet<GameObject> pickedUpObjects; // Track picked up objects
    // ======================================== methods ========================================
    private void Start()
    {
        pickedUpObjects = new HashSet<GameObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pickable") && !pickedup)
        {
            interactable = true;
            objTransform = other.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // mouse left click
        if(Input.GetMouseButtonDown(0)
        && other.CompareTag("Pickable") && !pickedup)
        {
            PickupObject();
        }
    }
    private void Update()
    {
        if (interactable)
        {
            Debug.Log("Interactable");
            if (Input.GetMouseButtonDown(0))
            {
                if (!(pickedup && pickedUpObjects.Contains(objTransform.gameObject)))
                {
                    PickupObject();
                }
            }

            if (Input.GetKeyDown(KeyCode.Q) && pickedup && pickedUpObjects.Contains(objTransform.gameObject))
                    ReleaseObject();

            if (pickedup && Input.GetKeyDown(KeyCode.E))
                    ThrowObject();
        }
    }

    private bool IsObjectPickedUp()
    {
        return pickedup && pickedUpObjects.Contains(objTransform.gameObject);
    }

    private void PickupObject()
    {
        Debug.Log("Picking up object");
        objTransform.SetParent(playerTransform);
        objTransform.GetComponent<Rigidbody>().isKinematic = true;
        pickedup = true;
        pickedUpObjects.Add(objTransform.gameObject);
    }

    private void ReleaseObject()
    {
        Debug.Log("Releasing object");
        objTransform.SetParent(null);
        objTransform.GetComponent<Rigidbody>().useGravity = true;
        pickedup = false;
        pickedUpObjects.Remove(objTransform.gameObject);
    }

    private void ThrowObject()
    {
        Debug.Log("Throwing object");
        ReleaseObject();

        // Check if the Shift key is pressed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            return; // Exit the method without applying any throwing force
        }
        objTransform.GetComponent<Rigidbody>().AddForce(playerTransform.forward * throwForce, ForceMode.Impulse);

        objTransform.GetComponent<Rigidbody>().isKinematic = false;
        // use gravity if you want the object to fall back down
        objTransform.GetComponent<Rigidbody>().useGravity = true;
        objTransform = null;
    }
}
