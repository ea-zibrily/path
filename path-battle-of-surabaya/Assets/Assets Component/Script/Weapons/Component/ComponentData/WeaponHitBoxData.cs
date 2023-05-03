using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class WeaponHitBoxData : ComponentData<AttackHitBox>
    {
        // [field: SerializeField] public AttackHitBox[] AttackHitBoxes { get; private set; }
        [field: SerializeField] public LayerMask HitLayerMask { get; private set; }

        public WeaponHitBoxData()
        {
            ComponentDependency = typeof(WeaponHitBox);
        }
    }
}