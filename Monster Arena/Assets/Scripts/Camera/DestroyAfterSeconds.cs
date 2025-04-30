using UnityEngine;

/// <summary>
/// This script destroys the GameObject it is attached to after a specified number of seconds.
/// </summary>
public class DestroyAfterSeconds : MonoBehaviour
{
    public float secondsToDestroy = 5f; // Time in seconds before the GameObject is destroyed
    
    void Start()
    {
        Destroy(gameObject, secondsToDestroy); // Schedule the GameObject for destruction
    }


}
