using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    public class BaseAttackData
    {
        [SerializeField] private string name;

        public void SetAttackName(int i) => name = $"Attack {i}";
    }
}