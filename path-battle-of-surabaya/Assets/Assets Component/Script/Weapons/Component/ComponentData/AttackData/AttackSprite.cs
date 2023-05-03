using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    [Serializable]
    public class BaseAttackSprite: BaseAttackData
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
    
    [Serializable]
    public class AttackSprite: BaseAttackData
    {
        public BaseAttackSprite[] weaponDirection;
    }
    
    
}