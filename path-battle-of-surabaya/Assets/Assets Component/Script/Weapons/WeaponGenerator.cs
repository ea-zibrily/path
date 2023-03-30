using System;
using System.Collections.Generic;
using System.Linq;
using Tsukuyomi.Weapons.Component;
using UnityEngine;

namespace Tsukuyomi.Weapons
{
    public class WeaponGenerator : MonoBehaviour
    {
        [SerializeField] private WeaponBase weaponBase;
        [SerializeField] private WeaponData weaponDataSO;

        private List<WeaponComponent> componentAlreadyOnWeapon = new List<WeaponComponent>();
        private List<WeaponComponent> componentAddedToWeapon = new List<WeaponComponent>();
        private List<Type> componentDependencies = new List<Type>();

        private void Start()
        {
            GenerateWeapon(weaponDataSO);
        }

        public void GenerateWeapon(WeaponData data)
        {
            weaponBase.SetScriptableObjectData(data);
            
            componentAlreadyOnWeapon.Clear();
            componentAddedToWeapon.Clear();
            componentDependencies.Clear();
            
            componentAlreadyOnWeapon = GetComponents<WeaponComponent>().ToList();
            componentDependencies = data.GetAllDependencies().ToList();

            foreach (var dependency in componentDependencies)
            {
                if (componentAlreadyOnWeapon.FirstOrDefault(t => t.GetType() == dependency))
                {
                    continue;
                }

                var weaponComponent = componentAlreadyOnWeapon.FirstOrDefault(t
                    => t.GetType() == dependency);

                if (weaponComponent == null)
                {
                    weaponComponent = gameObject.AddComponent(dependency) as WeaponComponent;
                }

                weaponComponent.Init();
                
                componentAddedToWeapon.Add(weaponComponent);
            }
            
            var componentsToRemove = componentAlreadyOnWeapon.Except(componentAddedToWeapon);
            
            foreach (var component in componentsToRemove)
            {
                Destroy(component);
            }
        }
    }
}