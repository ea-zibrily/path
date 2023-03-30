using System;
using System.Collections.Generic;
using System.Linq;
using Tsukuyomi.Weapons;
using Tsukuyomi.Weapons.Component;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObject Data/Weapon/New Weapon Data", order = 0)]
public class WeaponData : ScriptableObject
{
    [Header("Identity Component")] 
    public string weaponName;
    public WeaponType WeaponType;
    public WeaponCodeName weaponCodeName;
    [TextArea(5, 1)] public string weaponDescription;

    [Header("Attack Component")]
    public float maxAmmo;
    public float weaponDamage;
    [field: SerializeField] public int maxAttackCounter { get; private set; }
    [field: SerializeReference] public List<ComponentData> WeaponComponentData { get; private set; }
    
    // method ini dibuat untuk nge"reference" data
    // kurleb kek get component lah
    public T GetData<T>()
    {
        return WeaponComponentData.OfType<T>().FirstOrDefault();
    }

    public void AddData(ComponentData componentData)
    {
        if (WeaponComponentData.FirstOrDefault(t => t.GetType() == componentData.GetType()) != null)
        {
            return;
        }
        WeaponComponentData.Add(componentData);
    }

    public List<Type> GetAllDependencies()
    {
        return WeaponComponentData.Select(data =>data.ComponentDependency).ToList();
    }
    
    // Redundance Code
    // [ContextMenu("Add Sprite Data")]
    // private void AddSprite() => WeaponComponentData.Add(new WeaponSpriteData());
    //
    // [ContextMenu("Add Movement Data")]
    // private void AddMovement() => WeaponComponentData.Add(new MovementData());


}
