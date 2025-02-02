using System;
using UnityEngine;

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

    private void Update()
    {

        Vector3 direction = previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);

        camera.transform.position = target.position;
        //Rotate around x axis. Vertical.
        _rotationXAxis = Mathf.Clamp(_rotationXAxis + direction.y * 180, -15, 45);

        //This does a cool tilt effect like from an FPS. Leaving here just in case.
        // transform.rotation = Quaternion.Euler(0, 0, _rotation);

        
        // transform.rotation = Quaternion.Euler(_rotation, 0, 0);
        
        //Rotate around y axis. Horizontal
        _rotationYAxis = _rotationYAxis + -direction.x * 180;
        
        transform.rotation = Quaternion.Euler(_rotationXAxis, _rotationYAxis, 0);
            // camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);

        // camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
        camera.transform.Translate(new Vector3(adjustX, adjustY, adjustZ));

        previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);

    }
}
