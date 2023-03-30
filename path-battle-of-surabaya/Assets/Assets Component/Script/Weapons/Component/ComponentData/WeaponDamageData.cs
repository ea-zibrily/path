using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponDamageData : ComponentData<AttackDamage>
    {
        public WeaponDamageData()
        {
            ComponentDependency = typeof(WeaponDamage);
        }
    }
}