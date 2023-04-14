using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerMain : MonoBehaviour
{ 
    [Header("Scriptable Object Component")]
    public PlayerData playerDataSO;

    [Header("Player Movement Component")]
    [SerializeField] private float normalSpeed;
    public Vector2 movementDirection;

    [Space]
    public bool isSprint;
    public bool isShoot;
    public bool isPlayerAttack;

    [Header("Reference")]
    private Rigidbody2D myRb;
    private Animator myAnim;

    #region MonoBehaviour Method

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        gameObject.name = playerDataSO.playerName;
    }

    private void Start()
    {
        normalSpeed = playerDataSO.originalSpeed;
    }

    private void Update()
    {
        #region Sprint
        PlayerSprint();
        #endregion
    }

    private void FixedUpdate()
    {
        #region Movement
        PlayerMovement();
        PlayerMovementAnimation();
        #endregion
    }

    #endregion

    #region Tsukuyomi Method

    private void PlayerMovement()
    {
        // if (isPlayerAttack || DialogueManager.Instance.isDialogueActive)
        // {
        //     SetZeroVelocity();
        //     return;
        // }
        
        float x, y;
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
        movementDirection = new Vector2(x, y); 
        movementDirection.Normalize();
        myRb.velocity = movementDirection * normalSpeed;
    }

    private void PlayerMovementAnimation()
    {
        if (myRb.velocity != Vector2.zero)
        {
            myAnim.SetFloat("Horizontal", movementDirection.x);
            myAnim.SetFloat("Vertical", movementDirection.y);
            myAnim.SetBool("isWalk", true);
        }
        else
        {
            myAnim.SetBool("isWalk", false);
        }
    }

    private void PlayerSprint()
    {
        if (PlayerManager.Instance.isEnergyRegen)
        {
            isSprint = Input.GetKey(KeyCode.LeftShift);
            normalSpeed = isSprint ? playerDataSO.sprintSpeed : playerDataSO.originalSpeed;
        }
    }
    
    public void SetVelocity(Vector2 direction, float velocity)
    {
        myRb.velocity = direction * velocity;
    }

    public void SetZeroVelocity()
    {
        myRb.velocity = Vector2.zero;
    }
    
    #endregion
}


