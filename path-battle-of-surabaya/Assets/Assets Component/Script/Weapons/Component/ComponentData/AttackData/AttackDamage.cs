using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    [Serializable]
    public class AttackDamage : BaseAttackData
    {
        [field: SerializeField] public float WeaponDamage { get; private set; }
    }
}