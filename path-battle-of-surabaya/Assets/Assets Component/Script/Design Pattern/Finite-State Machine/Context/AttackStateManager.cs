using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tsukuyomi.Weapons;
using CodeMonkey.Utils;

public class AttackStateManager : MonoBehaviour
{
    [Header("Aim Component")] 
    public Vector2 playerAimDirection;

    [Header("Attack State Component")]
    [SerializeField] private string[] animationBoolName;
    public AttackMainState primaryAttackState { get; private set; }
    public AttackMainState secondaryAttackState { get; private set; }
    public AttackIdleState idleAttackState { get; private set; }

    [Header("Reference")]
    Rigidbody2D myRb;
    public Animator myAnim { get; private set; }
    private PlayerMainController _playerMainController;
    private WeaponBase primaryWeapon;
    private WeaponBase secondaryWeapon;
    public AttackStateMethod attackStateMethod { get; private set; }


    private void Awake()
    {
        _playerMainController = GetComponent<PlayerMainController>();
        primaryWeapon = transform.Find("PrimaryWeapon").GetComponent<WeaponBase>();
        secondaryWeapon = transform.Find("SecondaryWeapon").GetComponent<WeaponBase>();
        myAnim = GetComponent<Animator>();

        attackStateMethod = new AttackStateMethod();

        primaryAttackState = new AttackMainState(_playerMainController,this, attackStateMethod, animationBoolName[0], primaryWeapon);
        secondaryAttackState = new AttackMainState(_playerMainController,this, attackStateMethod, animationBoolName[1], secondaryWeapon);
        idleAttackState = new AttackIdleState(_playerMainController,this, attackStateMethod, animationBoolName[2]);
    }

    void Start()
    {   
        attackStateMethod.Initialize(idleAttackState);

    }

    void Update()
    {
        PlayerAim();
        
        attackStateMethod.currentState.LogicUpdate();

    }

    private void FixedUpdate()
    {
        attackStateMethod.currentState.PhysicsUpdate();
        
    }
    
    void PlayerAim()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
        Vector3 aimDirection = mousePosition - transform.position;
        aimDirection.Normalize();
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    
        playerAimDirection = new Vector2(aimDirection.x, aimDirection.y);
    }
}
