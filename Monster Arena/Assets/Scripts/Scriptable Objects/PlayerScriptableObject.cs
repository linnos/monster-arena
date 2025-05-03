using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "Scriptable Objects/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    //Max health
    public int health;
    public float stamina;
    public float movementSpeed;
    public float runSpeed;
    public float jumpSpeed;

    public float dodgeStaminaCost;
    public float runStaminaCost;

    public int numberOfBasicAttacks;

}
// This scriptable object is used to store the player stats. 
// It is used in the Player class to set the player stats.