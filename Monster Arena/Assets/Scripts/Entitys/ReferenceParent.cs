using UnityEngine;

//This class just exposes the parent of an object for other scripts to use.
public class ReferenceParent : MonoBehaviour
{
    [SerializeField]
    public GameObject parentObject;

    public GameObject ParentReference()
    {
        return parentObject;
    }
}
