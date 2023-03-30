using System;
using Tsukuyomi.Weapons.Component;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprite>
    {
        private SpriteRenderer baseSpriteRenderer;
        private SpriteRenderer weaponSpriteRenderer;
        
        [SerializeField] private int currentWeaponSprite;

        // private WeaponSpriteData spriteData;

        protected override void Start()
        {
            base.Start();
            
            baseSpriteRenderer = weaponBase.baseObj.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = weaponBase.weaponObj.GetComponent<SpriteRenderer>();

            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
            
            // Redundant Old SpriteRenderer
            // baseSpriteRenderer = transform.Find("Base").GetComponent<SpriteRenderer>();
            // weaponSpriteRenderer = transform.Find("WeaponSprite").GetComponent<SpriteRenderer>();
            
            //Redundant Old Reference SpriteData
            // Dia sama kek get component, karena di class weapon sprite data ini ada di SO
            // jadi perlu ngerefer SOnya dulu
            // spriteData = weaponBase.WeaponDataSO.GetData<WeaponSpriteData>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);
        }

        protected override void HandleWeaponEnter()
        {
            base.HandleWeaponEnter();
            
            currentWeaponSprite = 0;
        }

        protected override void HandleWeaponExit()
        {
            base.HandleWeaponExit();
            
            currentWeaponSprite = 0;
        }

        private void HandleBaseSpriteChange(SpriteRenderer mySr)
        {
            if (!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null;
                return;
            }
            
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

            // var currentAttackSprites = weaponData.WeaponSprites[weaponBase.CurrentCounter].weaponDirection[directionCondition].Sprites;
            var currentAttackSprites = currentAttackData.weaponDirection[weaponDirection].Sprites;
            if (currentWeaponSprite >= currentAttackSprites.Length)
            {
                Debug.LogWarning($"{weaponBase.name} is kebanyakan lor anjoy");
                return;
            }
            
            weaponSpriteRenderer.sprite = currentAttackSprites[currentWeaponSprite];
            currentWeaponSprite++;
        }
    }
}