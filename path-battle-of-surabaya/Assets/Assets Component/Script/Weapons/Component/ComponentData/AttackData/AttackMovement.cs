using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    [Serializable]
    public class BaseAttackMovement : BaseAttackData
    {
        [field: SerializeField] public Vector2 Direction { get; private set; }
        [field: SerializeField] public float Velocity { get; private set; }
    }

    [Serializable]
    public class  AttackMovement: BaseAttackData
    {
        public BaseAttackMovement[] DirectionAttackMovement;
    }
}