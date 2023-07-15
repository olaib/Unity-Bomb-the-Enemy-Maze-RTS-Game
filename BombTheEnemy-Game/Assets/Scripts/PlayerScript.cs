using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerScript : MonoBehaviour
{
    // // ================================== VARIABLES ========================================\\
    // [SerializeField] private float SPEED = 5f;
    // [SerializeField] private float GRAVITY = 20f;
    // [SerializeField] private float JUMP_HEIGHT = 5f;
    // private Vector3 velocity;
    // public Dictionary<KeyCode, Vector3> keyToMovement = new Dictionary<KeyCode, Vector3>();

    // private CharacterController controller;
    // // ================================== SINGLETON ========================================\\
    // public static PlayerScript Instance { get; private set; }    
    // private Vector3 offset;
    // public Transform target;
    // public float smoothing = 0.125f;
    // private void Awake()
    // {
    //     // Make sure only one instance of the script exists
    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    //     Instance = this;
    // }

    // private void Start()
    // {
    //     controller = GetComponent<CharacterController>();
    //     controller.enableOverlapRecovery = true;

    //     // Map keys to movement directions
    //     keyToMovement[KeyCode.W] = Vector3.forward;
    //     keyToMovement[KeyCode.S] = Vector3.back;
    //     keyToMovement[KeyCode.A] = Vector3.left;
    //     keyToMovement[KeyCode.D] = Vector3.right;
    // }
    // // private void FixedUpdate()
    // // {
    // //     Vector3 desiredPosition = target.position + offset;
    // //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothing);
    // //     transform.position = smoothedPosition;

    // //     transform.LookAt(target);
    // // }
    // private void Update()
    // {

    //     Vector3 movementDirection = Vector3.zero;

    //     // Check for movement keys and add to movement direction
    //     foreach (KeyValuePair<KeyCode, Vector3> entry in keyToMovement)
    //     {
    //         if (Input.GetKey(entry.Key))
    //         {
    //             movementDirection += entry.Value;
    //         }
    //     }

    //     // normalized movement direction
    //     Vector3 movement = movementDirection.normalized * SPEED * Time.deltaTime;

    //     // Move the player
    //     controller.Move(movement);

    //     // Apply gravity when not grounded
    //     if (controller.isGrounded)
    //     {
    //         velocity.y = -1;
    //     }
    //     else
    //     {
    //         velocity.y -= GRAVITY * Time.deltaTime;  
    //     }

    //     // Jump
    //     if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
    //     {
    //         velocity.y = Mathf.Sqrt(JUMP_HEIGHT * -2f * GRAVITY);
    //     }
    
    //     // Apply velocity
    //     controller.Move(velocity * Time.deltaTime);
    // }
}