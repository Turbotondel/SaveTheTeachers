using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public PlayerData playerData;
    public Light keyLight;

    private void Start()
    {
        keyLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsInventoryItem(other.gameObject))
        {
            AddItemToInventory(other.gameObject);
        }
    }

    private void AddItemToInventory(GameObject item)
    {
        if (IsInventoryItem(item))
        {
            playerData.inventory.Add(item);
        }
    }

    private bool IsInventoryItem(GameObject item)
    {
        return item.CompareTag("Key")
            || item.CompareTag("Scissors");
    }

    private bool UseKey()
    {
        foreach (var item in playerData.inventory)
        {
            if (item.CompareTag("Key"))
            {
                playerData.inventory.Remove(item);
                return true;
            }
        }

        return false;
    }

    private bool HasScissors()
    {
        foreach (var item in playerData.inventory)
        {
            if (item.CompareTag("Scissors"))
            {
                return true;
            }
        }

        return false;
    }

    void SaveFrank()
    {
        playerData.frankRescued = true;
    }

    void SaveJeff()
    {
        playerData.jeffRescued = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }
    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Key" || interactedObject.tag == "Scissors")
            {
                AddItemToInventory(interactedObject);
                interactedObject.SetActive(false);
            }
            else if (interactedObject.tag == "Wires")
            {
                if (HasScissors())
                {
                    interactedObject.SetActive(false);
                    keyLight.enabled = true;
                }
            }
            else if (interactedObject.tag == "Locked Door")
            {
                if(UseKey())
                {
                    interactedObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("missed ray");
            }
        }
    }
}
