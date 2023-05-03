using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponHitBox : WeaponComponent<WeaponHitBoxData, AttackHitBox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2D;
        private Vector2 offset;
        private Collider2D[] colliderDetector;

        protected override void Start()
        {
            base.Start();
            
            weaponAnimHandler.OnAttackAction += HandleAttackAction;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            weaponAnimHandler.OnAttackAction -= HandleAttackAction;
        }
        
        private void HandleAttackAction()
        {
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
            var aimDirection = weaponBase.playerAttackStateManager.playerAimDirection; 
            offset.Set(transform.position.x + (currentAttackData.hitBoxDirection[weaponDirection].HitBox.center.x * 
                                               aimDirection.x),
                transform.position.y + (currentAttackData.hitBoxDirection[weaponDirection].HitBox.center.y * 
                                        aimDirection.y));

            colliderDetector = Physics2D.OverlapBoxAll(offset, currentAttackData.hitBoxDirection[weaponDirection].HitBox.size, 
                0f, weaponData.HitLayerMask);

            if (colliderDetector.Length == 0)
            {
                return;
            }

            OnDetectedCollider2D?.Invoke(colliderDetector);
        }

        private void OnDrawGizmosSelected()
        {
            #region Check Weapon Data

            if (weaponData == null)
            {
                return;
            }

            #endregion

            foreach (var item in weaponData.AttackData)
            {
                if (!item.Debug)
                {
                    continue;
                }

                Gizmos.color = Color.cyan;
                Gizmos.DrawWireCube(transform.position + (Vector3) item.hitBoxDirection[weaponDirection].HitBox.center,
                    item.hitBoxDirection[weaponDirection].HitBox.size);
            }
        }
    }
}