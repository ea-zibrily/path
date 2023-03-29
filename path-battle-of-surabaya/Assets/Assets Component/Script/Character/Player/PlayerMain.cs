using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    [Header("Scriptable Object Data")] 
    [SerializeField] private string test;
    [field: SerializeField] public PlayerData PlayerDataSO { get; private set; }

    [Header("Reference")] 
    private Rigidbody2D myRb;
    private Animator myAnim;
}
