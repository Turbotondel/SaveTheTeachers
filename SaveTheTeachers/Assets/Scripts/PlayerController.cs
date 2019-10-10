using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerData playerData;

    private void OnTriggerEnter(Collider other)
    {
        if(IsInventoryItem(other.gameObject))
        {
            addItemToInventory(other.gameObject);
        }
    }   

    public void addItemToInventory(GameObject item)
    {
        playerData.inventory.Add(item);
    }

    public bool IsInventoryItem(GameObject item)
    {
        return item.CompareTag("Key") || item.CompareTag("");
    }

    public bool UseKey()
    {
        foreach (var item in playerData.inventory)
        {
            if(item.CompareTag("Key"))
            {
                playerData.inventory.Remove(item);
                return true;
            }
        }

        return false;
    }
}
