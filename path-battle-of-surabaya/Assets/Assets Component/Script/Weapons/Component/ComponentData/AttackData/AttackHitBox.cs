using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    [Serializable]
    public class BaseAttackHitBox: BaseAttackData
    {
        [field: SerializeField] public Rect HitBox { get; private set; }
    }
    
    [Serializable]
    public class AttackHitBox: BaseAttackData
    {
        public bool Debug;
        public BaseAttackHitBox[] hitBoxDirection;
    }
}