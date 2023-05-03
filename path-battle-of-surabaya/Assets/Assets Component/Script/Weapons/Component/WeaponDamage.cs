using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponDamage : WeaponComponent<WeaponDamageData, AttackDamage>
    {
        private WeaponHitBox weaponHitBox;
        private EnemyManager enemyManager;

        protected override void Start()
        {
            base.Start();
            
            weaponHitBox = GetComponent<WeaponHitBox>();
            weaponHitBox.OnDetectedCollider2D += HandleDetectedCollider;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            weaponHitBox.OnDetectedCollider2D -= HandleDetectedCollider;
        }

        private void HandleDetectedCollider(Collider2D[] collider)
        {
            foreach (var enemy in collider)
            {
                enemyManager = enemy.gameObject.GetComponent<EnemyManager>();
                enemyManager.DecreaseHealth(currentAttackData.WeaponDamage);
            }
        }
    }
}