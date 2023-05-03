using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public abstract class WeaponComponent : MonoBehaviour
    {
        protected WeaponBase weaponBase;
        protected PlayerMainController PlayerMainController;
        protected WeaponAnimationEventHandler weaponAnimHandler;
        protected bool isAttackActive;
        protected int weaponDirection;

        public virtual void Init()
        {
            
        }
        
        protected virtual void Awake()
        {
            weaponBase = GetComponent<WeaponBase>();
            PlayerMainController = GetComponentInParent<PlayerMainController>();
            weaponAnimHandler = GetComponentInChildren<WeaponAnimationEventHandler>();
        }

        protected virtual void Start()
        {
            weaponBase.OnEnter += HandleWeaponEnter;
            weaponBase.OnExit += HandleWeaponExit;
        }

        protected virtual void OnDestroy()
        {
            weaponBase.OnEnter -= HandleWeaponEnter;
            weaponBase.OnExit -= HandleWeaponExit;
        }

        protected virtual void HandleWeaponEnter()
        {
            isAttackActive = true;
        }
        protected virtual void HandleWeaponExit()
        {
            isAttackActive = false;
        }
    }
    
    //Make generic class
    public abstract class WeaponComponent<T1, T2>: WeaponComponent where T1: ComponentData<T2> where T2 : BaseAttackData
    {
        protected T1 weaponData;
        protected T2 currentAttackData;

        protected override void HandleWeaponEnter()
        {
            base.HandleWeaponEnter();
            
            currentAttackData = weaponData.AttackData[weaponBase.CurrentCounter];
        }

        // protected override void Awake()
        // {
        //     base.Awake();
        //     weaponData = weaponBase.WeaponDataSO.GetData<T1>();
        // }
        
        public override void Init()
        {
            base.Init();
            
            weaponData = weaponBase.WeaponDataSO.GetData<T1>();
        }
        
    }
}