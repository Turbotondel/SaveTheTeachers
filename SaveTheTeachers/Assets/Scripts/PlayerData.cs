using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int health;
    public List<GameObject> inventory = new List<GameObject>();
    public bool fusionAchieved;
    public bool jeffRescued;
}
