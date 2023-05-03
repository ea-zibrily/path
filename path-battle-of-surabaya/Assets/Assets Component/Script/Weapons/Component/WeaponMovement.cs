using Tsukuyomi.Weapons.Component;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponMovement : WeaponComponent<WeaponMovementData, AttackMovement>
    {
        // ga perlu manggil script movement data lagi
        // karena udah di ext di atas
        // private MovementData movementData;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            
            weaponAnimHandler.OnStartMovement += HandleStartMovement;
            weaponAnimHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            weaponAnimHandler.OnStartMovement -= HandleStartMovement;
            weaponAnimHandler.OnStopMovement -= HandleStopMovement;
        }

        private void HandleStartMovement()
        {
            // var attackCurrentData = weaponData.attackMovementData[weaponBase.CurrentCounter]
            //     .DirectionAttackMovement[directionCondition];
            var attackCurrentData = currentAttackData.DirectionAttackMovement[weaponDirection];
            
            #region Direction Condition

            if (weaponBase.playerAttackStateManager.playerAimDirection.x > 0.0f
                && weaponBase.playerAttackStateManager.playerAimDirection.y <= 0.5f
                && weaponBase.playerAttackStateManager.playerAimDirection.y >= -0.5f)
            {
                weaponDirection = 0;
            }
            
            if (weaponBase.playerAttackStateManager.playerAimDirection.x < 0.0f
                && weaponBase.playerAttackStateManager.playerAimDirection.y <= 0.5f
                && weaponBase.playerAttackStateManager.playerAimDirection.y >= -0.5f)
            {
                weaponDirection = 1;
            }
            
            if (weaponBase.playerAttackStateManager.playerAimDirection.y > 0.0f
                && weaponBase.playerAttackStateManager.playerAimDirection.x <= 0.5f
                && weaponBase.playerAttackStateManager.playerAimDirection.x >= -0.5f)
            {
                weaponDirection = 2;
            }
            
            if (weaponBase.playerAttackStateManager.playerAimDirection.y < 0.0f
                && weaponBase.playerAttackStateManager.playerAimDirection.x <= 0.5f
                && weaponBase.playerAttackStateManager.playerAimDirection.x >= -0.5f)
            {
                weaponDirection = 3;
            }

            #endregion

            PlayerMainController.SetVelocity(attackCurrentData.Direction, attackCurrentData.Velocity);
        }
        
        private void HandleStopMovement()
        {
            PlayerMainController.SetZeroVelocity();
        }
    }
}