using Tsukuyomi.Weapons.Component;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponMovementData : ComponentData<AttackMovement>
    {
        // [field: SerializeField] public AttackMovement[] attackMovementData { get; private set; }
        public WeaponMovementData()
        {
            ComponentDependency = typeof(WeaponMovement);
        }
    }
}