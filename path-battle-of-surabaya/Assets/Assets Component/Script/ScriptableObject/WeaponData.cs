using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObject Data/Weapon/New Weapon Data", order = 1)]
public class WeaponData : ScriptableObject
{
    [Header("General Component")]
    public string weaponName;
    public WeaponType weaponType;
    [TextArea(3, 10)] public string weaponDescription;
    
    [Header("Main Component")]
    public float weaponDamage;
    public float weaponMaxAmmo;
    public float weaponRange;
    public float weaponMaxAttackCounter;
}