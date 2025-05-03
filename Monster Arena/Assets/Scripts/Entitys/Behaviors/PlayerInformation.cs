using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
    public Player player;

    void Start()
    {
        if(!player){
            throw new System.Exception("Player is not assigned in PlayerInformation script. Please assign it in the inspector.");
        }
    }

    public bool isPlayerInState(string stateName){
        string currentStateName = player.stateMachine.currentState.GetType().Name.ToLower();

        if(currentStateName == stateName.ToLower()){
            return true;
        }

        return false;
    }

    
}
