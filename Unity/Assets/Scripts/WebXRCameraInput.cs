using UnityEngine;

public class WebXRCameraInput : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 25.0f;

    void Update()
    {
        // Check for movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Adjust camera position based on input
        transform.position += transform.right * horizontalInput * moveSpeed * Time.deltaTime;
        transform.position += transform.forward * verticalInput * moveSpeed * Time.deltaTime;

        // Check for rotation input
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.left, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.V))
        {
            transform.Rotate(Vector3.left, rotateSpeed * Time.deltaTime);
        }

         if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
        }
    }
}
