using UnityEngine;

public class FollowBehind : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float adjustX;
    public float adjustZ;

    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTransform.x = adjustX + target.transform.position.x;
        targetTransform.y = this.transform.position.y;
        targetTransform.z = adjustZ + target.transform.position.z;
        
        this.transform.position = targetTransform;
    }

}
