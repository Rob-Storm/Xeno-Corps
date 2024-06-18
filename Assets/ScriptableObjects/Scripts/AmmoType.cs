using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Type", menuName = "Weapons/Create New Ammo Type")]
public class AmmoType : ObjectBase
{
    [Header("Ammo Stats")]
    public int Damage;
}
