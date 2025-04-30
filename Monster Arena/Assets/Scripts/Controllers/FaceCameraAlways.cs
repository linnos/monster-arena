using UnityEngine;

public class FaceCameraAlways : MonoBehaviour
{
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera.transform);
        transform.Rotate(0, 180, 0); // Rotate to face the camera correctly
    }
}
