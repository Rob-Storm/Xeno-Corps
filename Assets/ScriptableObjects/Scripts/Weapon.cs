using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/Create New Weapon")]
public class Weapon : ObjectBase
{
    [Header("Weapon Stats")]
    public AmmoType AmmoType;
}
