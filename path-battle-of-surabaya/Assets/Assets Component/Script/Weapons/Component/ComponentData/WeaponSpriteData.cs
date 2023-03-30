using Tsukuyomi.Weapons.Component;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponSpriteData : ComponentData<AttackSprite>
    {
        // [field: SerializeField] public WeaponDirectionSprites[] WeaponSprites { get; private set; }
        public WeaponSpriteData()
        {
            ComponentDependency = typeof(WeaponSprite);
        }
    }
}