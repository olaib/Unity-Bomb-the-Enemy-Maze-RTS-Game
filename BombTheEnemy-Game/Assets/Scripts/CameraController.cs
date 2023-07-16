using UnityEngine;
using Cinemachine;

// // public class CameraController : MonoBehaviour
// // {
// //     public CinemachineFreeLook freeLookCamera;
// //     public float rotationSpeed = 1f;
// //     public float zoomSpeed = 1f;
// //     public float minZoom = 5f;
// //     public float maxZoom = 15f;

// //     private float zoomInput;

// //     private void Update()
// //     {
// //         // Rotate or zoom camera around player when right mouse button is clicked
// //         if (Input.GetMouseButton(1))
// //         {
// //             // Get input for camera rotation and zoom
// //             float rotateInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
// //             float zoomInput = Input.GetAxis("Mouse Y") * zoomSpeed * Time.deltaTime;

// //             // Rotate camera around player
// //             freeLookCamera.m_XAxis.Value += rotateInput;

// //             // Zoom camera in and out
// //             freeLookCamera.m_Lens.FieldOfView += zoomInput;
// //             freeLookCamera.m_Lens.FieldOfView = Mathf.Clamp(freeLookCamera.m_Lens.FieldOfView, minZoom, maxZoom);
// //         }
// //     }
// // }
// using UnityEngine;
// using Cinemachine;

// public class CameraController : MonoBehaviour
// {
//     public CinemachineFreeLook freeLookCamera;
//     public float rotationSpeed = 1f;
//     public float zoomSpeed = 1f;
//     public float minZoom = 5f;
//     public float maxZoom = 15f;

//     public Transform playerTransform;
//     public float playerRotationSpeed = 1f;
//     public float jumpForce = 5f;

//     private float zoomInput;

//     private void Update()
//     {

//         // Get input for camera rotation and zoom
//         float rotateInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
//         float verticalRotateInput = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
//         zoomInput = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

//         // Rotate camera around player
//         freeLookCamera.m_XAxis.Value += rotateInput;

//         // Rotate camera vertically
//         freeLookCamera.m_YAxis.Value += verticalRotateInput;

//         // Zoom camera in and out
//         freeLookCamera.m_Lens.FieldOfView += zoomInput;
//         freeLookCamera.m_Lens.FieldOfView = Mathf.Clamp(freeLookCamera.m_Lens.FieldOfView, minZoom, maxZoom);

//         // Rotate player left and right based on camera rotation
//         float playerRotateInput = Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;
//         playerTransform.Rotate(0f, playerRotateInput, 0f);

//         // Jump
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
//             if (rb != null)
//             {
//                 rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
//             }
//         }
//     }
// }
public class CameraController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float rotationSpeed = 1f;
    public float zoomSpeed = 1f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public Transform playerTransform;
    public float playerRotationSpeed = 1f;
    public float jumpForce = 5f;

    private float zoomInput;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            // Get input for camera rotation and zoom
            float rotateInput = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
            float verticalRotateInput = Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime;
            zoomInput = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime;

            // Rotate camera around player
            freeLookCamera.m_XAxis.Value += rotateInput;

            // Rotate camera vertically
            freeLookCamera.m_YAxis.Value += verticalRotateInput;

            // Zoom camera in and out
            freeLookCamera.m_Lens.FieldOfView += zoomInput;
            freeLookCamera.m_Lens.FieldOfView = Mathf.Clamp(freeLookCamera.m_Lens.FieldOfView, minZoom, maxZoom);

            // Rotate player left and right based on camera rotation
            float playerRotateInput = Input.GetAxis("Horizontal") * playerRotationSpeed * Time.deltaTime;
            playerTransform.Rotate(0f, playerRotateInput, 0f);
        }
        // when player presses space, jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = playerTransform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}


