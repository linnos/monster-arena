using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] public Camera camera;
    [SerializeField] public Transform target;
    private Vector3 previousPosition;

    public float adjustX = 0;
    public float adjustY = 0;
    public float adjustZ = -2;

    private float _rotationXAxis;
    private float _rotationYAxis;

    Vector2 input;
    public Vector3 directions = Vector3.zero;

    public float cameraSpeed;

    private void LateUpdate()
    {

        Vector3 direction = previousPosition - camera.transform.position - directions;

        camera.transform.position = target.position;
        //Rotate around x axis. Vertical.
        _rotationXAxis = Mathf.Clamp(_rotationXAxis + direction.y * cameraSpeed, -15, 45);

        //This does a cool tilt effect like from an FPS. Leaving here just in case.
        // transform.rotation = Quaternion.Euler(0, 0, _rotation);

        
        // transform.rotation = Quaternion.Euler(_rotation, 0, 0);
        
        //Rotate around y axis. Horizontal
        _rotationYAxis = _rotationYAxis + -direction.x * cameraSpeed;
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0), cameraSpeed);
        // Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0);
            // camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);

        // camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
        camera.transform.Translate(new Vector3(adjustX, adjustY, adjustZ));

        previousPosition = camera.transform.position;

    }

    public void Look_Event(InputAction.CallbackContext context)
    {
        //TODO: find a way to change cameraXspeed and cameraYspeed so that
        //camera movement feels more fluid and you can adjust it.
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
