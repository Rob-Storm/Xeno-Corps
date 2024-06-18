using UnityEngine;

public class ObjectBase : ScriptableObject
{
    [Header("Basic Info")]
    public string Name;

    [Multiline]
    public string Description;

    public int Weight;

    public int priceBuy;
    public int priceSell;
}
