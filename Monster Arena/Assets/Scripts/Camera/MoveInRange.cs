using UnityEngine;

public class MoveInRange : MonoBehaviour
{
    [SerializeField][Range(0, 25)] float speed = 1f;
    [SerializeField][Range(0, 100)] float range = 1f;
    [SerializeField][Range(0, 50)] float initialRise = 1f;
    private float initialYPos = 0f;

    private bool completed = false;

    void Start()
    {
        initialYPos = transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        loop();
    }

    void loop()
    {
        if(transform.position.y < initialYPos + initialRise && !completed){
            float yPos = speed * Time.deltaTime + transform.position.y;
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        else{
            completed = true;
        }
    }
}
