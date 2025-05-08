using System;
using System.Collections.Generic;
using UnityEngine;

//A basic inventory system for a health potion.
//Will expand on this later to include other items and a UI.
public class Inventory : MonoBehaviour
{
    //Need to change this later, but for now, this will work.
    //it's an action that takes an int because thats houw much health the potion gives.
    public Action<int> OnItemUsed;
    public int numOfPotions = 3;
    
    //TODO: Remove this temporary potion code
    //This is just for testing purposes. Remove this when you have a proper item system.
    public List<GameObject> potionUIPrefab;

    private void Awake()
    {
        if(potionUIPrefab == null)
        {
            throw new Exception("Potion UI prefab is not assigned in the inspector.");
        }
        if(potionUIPrefab.Count == 0)
        {
            throw new Exception("Potion UI prefab list is empty in the inspector.");
        }
    }
    
    //Prepares the item for use. When the button is pressed, it will check if the item is available.
    //If it is, it will decrement the number of potions and return true.
    public bool PrepareItem(){
        if(numOfPotions > 0){
            numOfPotions--;
            potionUIPrefab[numOfPotions].SetActive(false);
            return true;
        }

        return false;
    }

    //When the item effect is popped.
    public void UseItem(){
        OnItemUsed?.Invoke(40);
    }

}
