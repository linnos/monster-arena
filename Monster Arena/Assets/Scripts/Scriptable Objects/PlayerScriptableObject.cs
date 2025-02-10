using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable Objects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public int health;
    public float movementSpeed;
    public float runSpeed;
    public float jumpSpeed;

    public int numberOfBasicAttacks;

}
