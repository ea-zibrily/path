using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObject Data/Player/New Player Data", order = 0)]
public class PlayerData : ScriptableObject
{
    [Header("General")] 
    public string playerName;

    [Header("Movement")]
    public float moveSpeed;
    public float maxMoveSpeed;

}