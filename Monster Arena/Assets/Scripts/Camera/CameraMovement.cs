using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public Transform target;
    private Vector3 previousPosition;

    //Adjust position of camera
    public float adjustX = 0;
    public float adjustY = 0;
    public float adjustZ = -2;

    //Adjust camera x and y speed individually
    public float adjustXSpeed = 1;
    public float adjustYSpeed = 1;

    private float _rotationXAxis;
    private float _rotationYAxis;

    Vector2 input;
    public Vector3 directions = Vector3.zero;

    public float cameraSpeed;

    private void LateUpdate()
    {

        Vector3 direction = previousPosition - cam.transform.position - directions;

        cam.transform.position = target.position;
        //Rotate around x axis. Vertical.
        _rotationXAxis = Mathf.Clamp(_rotationXAxis + direction.y * cameraSpeed * adjustYSpeed, -15, 45);

        //This does a cool tilt effect like from an FPS. Leaving here just in case.
        // transform.rotation = Quaternion.Euler(0, 0, _rotation);

        
        // transform.rotation = Quaternion.Euler(_rotation, 0, 0);
        
        //Rotate around y axis. Horizontal
        _rotationYAxis = _rotationYAxis + -direction.x * cameraSpeed * adjustXSpeed;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0), cameraSpeed);
        // Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0);
            // camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);

        // camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
        cam.transform.Translate(new Vector3(adjustX, adjustY, adjustZ));

        previousPosition = cam.transform.position;

    }

    public void Look_Event(InputAction.CallbackContext context)
    {
        //TODO: find a way to make camera movement feel more fluid.
        if (context.started)
        {
           
        }
        else if (context.performed)
        {
            input = context.ReadValue<Vector2>();
            directions.x = Mathf.Clamp(input.x, -1f, 1);
            directions.y = Mathf.Clamp(input.y, -1f, 1);
        }
        else if (context.canceled)
        {
            directions.x = 0f;
            directions.y = 0f;
        }

    }
}
