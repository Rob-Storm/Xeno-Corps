using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Stats", menuName = "Create New Unit Stats")]
public class UnitStats : ScriptableObject
{
    [Header("Unit Stats")]
    [Header("Primary Stats")]
    public int Bravery;
    public int Reactions;
    public int FiringAccuracy;
    public int ThrowingAccuracy;

    [Header("Secondary Stats")]
    public int TimeUnits;
    public int Stamina;
    public int Health;
    public int Strength;

    [Header("Misc")]
    UnitRank Rank = UnitRank.Rookie;
}

public enum UnitRank
{
    Rookie,
    Squaddie,
    Sergeant,
    Captain,
    Colonel,
    Commander
}