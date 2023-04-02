using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tsukuyomi.Utilities;
using UnityEngine.Serialization;

namespace Tsukuyomi.Weapons
{
    public class WeaponBase : MonoBehaviour
    {
        #region Scriptable Object Component
        
        public WeaponData WeaponDataSO { get; private set; }
        
        #endregion
        
        #region Event Action
        public event Action OnEnter;
        public event Action OnExit;
        
        #endregion
        
        #region Setup Attack Counter
        
        private Timer counterResetTimer;
        [SerializeField] private float timeResetCurrentCounter;
        private int _currentCounter;
        public int CurrentCounter
        {
            get => _currentCounter;
            private set => _currentCounter = value >= WeaponDataSO.maxAttackCounter ? 0 : value;
        }
        
        #endregion
        
        #region Reference
        
        public GameObject baseObj { get; private set; }
        public GameObject weaponObj { get; private set; }
        private Animator myAnim;
        // [FormerlySerializedAs("weaponAnimHandler")]
        public WeaponAnimationEventHandler WeaponAnimHandler {get; private set;}

        private GameObject playerObj;
        private Animator playerAnim;
        public AttackStateManager playerAttackStateManager { get; private set; }
        private PlayerMain playerMain;
        
        #endregion

        private void OnEnable()
        {
            //On finish ni nge"subscribe" method WeaponExit
            //dimana misal event OnFinish dipanggil, maka method WeaponExit bakal ikut kepanggil
            
            WeaponAnimHandler.OnFinish += WeaponExit;
            counterResetTimer.OnTimerDone += CounterResetAttackCounter;
        }

        private void OnDisable()
        {
            //On finish ni nge"subscribe" method WeaponExit
            //dimana misal event OnFinish dipanggil, maka method WeaponExit bakal ikut kepanggil
            
            WeaponAnimHandler.OnFinish -= WeaponExit;
            counterResetTimer.OnTimerDone -= CounterResetAttackCounter;
        }

        private void Awake()
        {
            baseObj = transform.Find("Base").gameObject;
            weaponObj = transform.Find("WeaponSprite").gameObject;
            myAnim = baseObj.GetComponent<Animator>();
            WeaponAnimHandler = baseObj.GetComponent<WeaponAnimationEventHandler>();

            playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
            playerAnim = playerObj.GetComponent<Animator>();
            playerAttackStateManager = playerObj.GetComponent<AttackStateManager>();
            playerMain = playerObj.GetComponent<PlayerMain>();

            counterResetTimer = new Timer(timeResetCurrentCounter);
        }

        private void Update()
        {
            counterResetTimer.Tick();
        }
        
        public void SetScriptableObjectData(WeaponData weaponData)
        {
            WeaponDataSO = weaponData;
        }

        public void WeaponEnter()
        {
            PlayerDirectionBeforeAttack();
            
            counterResetTimer.StopTimer();
            OnEnter?.Invoke();
        }

        public void WeaponExit()
        {
            PlayerDirectionAfterAttack();

            //Current = Properties y masbro karena pake getset
            CurrentCounter++;
            counterResetTimer.StartTimer();
            OnExit?.Invoke();
        }

        void PlayerDirectionBeforeAttack()
        {
            myAnim.SetFloat("Horizontal", playerAttackStateManager.playerAimDirection.x);
            myAnim.SetFloat("Vertical", playerAttackStateManager.playerAimDirection.y);
            myAnim.SetBool("isAttack", true);
            
            //Current = Properties y masbro karena pake getset
            // myAnim.SetInteger("Counter", CurrentCounter);
        }

        void PlayerDirectionAfterAttack()
        {
            playerAnim.SetFloat("Horizontal", playerAttackStateManager.playerAimDirection.x);
            playerAnim.SetFloat("Vertical", playerAttackStateManager.playerAimDirection.y);
            myAnim.SetBool("isAttack", false);
        }

        private void CounterResetAttackCounter() => CurrentCounter = 0;
    }
}
