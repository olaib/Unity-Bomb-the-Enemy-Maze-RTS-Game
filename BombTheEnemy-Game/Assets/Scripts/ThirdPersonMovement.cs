using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    // =========================== ZOOM VARIABLES ===========================
    // public float zoomSpeed = 2f; // for zoom speed
    // public float minZoom = 2f; // for minimum zoom distance
    // public float maxZoom = 10f; //for maximum zoom distance
    // float currentZoom = 5f; // for zoom distance
    // =============================== METHODS ================================
    void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered with " + other.gameObject.name + "");
        if (other.gameObject.name == "Won")
        {
            GameManager.Instance().LevelCompleted();
        }
    }

    void Update()
    {
        //if shift is pressed, run
        speed = (Input.GetKey(KeyCode.LeftShift) ? 12f : 6f);
        float horizontal = Input.GetAxis("Horizontal");//A and D keys
        float vertical = Input.GetAxis("Vertical");//W and S keys
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            // Rotate the player based on the input direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Move the player in the input direction
            Vector3 moveDir = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
