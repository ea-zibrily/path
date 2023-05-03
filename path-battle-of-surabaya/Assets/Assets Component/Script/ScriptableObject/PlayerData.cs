using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObject Data/Player/New Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public float originalSpeed;
    public float sprintSpeed;
    
}
