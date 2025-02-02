using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    private Vector3 previousPosition;

        public float adjustX = 0;
    public float adjustY = 0;
    public float adjustZ = -2;

    private void Update() {
        
            Vector3 direction = previousPosition - camera.ScreenToViewportPoint(Input.mousePosition);

            camera.transform.position = target.position;

            camera.transform.Rotate(new Vector3(1, 0, 0), direction.y * 180);
            camera.transform.Rotate(new Vector3(0, 1, 0), -direction.x * 180, Space.World);
            camera.transform.Translate(new Vector3(adjustX , adjustY, adjustZ));

            previousPosition = camera.ScreenToViewportPoint(Input.mousePosition);
        
    }
}
