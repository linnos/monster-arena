using UnityEngine;

public class FollowBehind : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float adjustX;
    public float adjustY;
    public float adjustZ;

    /// <summary>
    /// /////////
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    /// </summary>

    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        targetTransform.x = adjustX + target.transform.position.x;
        targetTransform.y = adjustY + target.transform.position.y;
        targetTransform.z = adjustZ + target.transform.position.z;
        
        this.transform.position = targetTransform;

        
    }

}
