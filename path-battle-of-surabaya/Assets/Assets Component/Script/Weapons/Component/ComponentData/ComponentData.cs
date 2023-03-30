using System;
using UnityEngine;

namespace Tsukuyomi.Weapons.Component
{
    [Serializable]
    public class ComponentData
    {
        [SerializeField] private string name;
        public Type ComponentDependency { get; protected set; }
        
        public ComponentData() => SetComponentName();
        public void SetComponentName() => name = GetType().Name;
        public virtual void SetAttackDataNames(){}
        public virtual void InitializeAttackData(int maxAttackCounter){}
    }
    
    [Serializable]
    public class ComponentData<T> : ComponentData where T : BaseAttackData
    {
        [SerializeField] private T[] _attackData;
        public T[] AttackData { get => _attackData; private set => _attackData = value; }

        public override void SetAttackDataNames()
        {
            base.SetAttackDataNames();
            
            for (var i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i+1);
            }
        }

        public override void InitializeAttackData(int maxAttackCounter)
        {
            base.InitializeAttackData(maxAttackCounter);
            
            var oldLength = _attackData != null? _attackData.Length : 0;

            if (oldLength == maxAttackCounter)
            {
                return;
            }
            
            Array.Resize(ref _attackData, maxAttackCounter);

            if (oldLength < maxAttackCounter)
            {
                for (var i = oldLength; i < _attackData.Length; i++)
                {
                    var newObj = Activator.CreateInstance(typeof(T)) as T;
                    _attackData[i] = newObj;
                }
            }
            
            SetAttackDataNames();
        }
    }
}