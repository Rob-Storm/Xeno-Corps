using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private bool IsSelected { get; set; } = false;

    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private UnitStats stats;
    public int TimeUnits { get; set; } = 40;
    public string Name { get; set; }

    [SerializeField] private NamesTable FirstNamesList;
    [SerializeField] private NamesTable LastNamesList;

    [SerializeField] private InventoryComponent inventoryComponent;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        System.Random random = new System.Random();
        Name = $"{FirstNamesList.Name[random.Next(0, 9)]} {LastNamesList.Name[random.Next(0,9)]}";
    }

    public InventoryComponent GetInventory() => inventoryComponent;

    public UnitStats GetStats() => stats;
    public void Select()
    {
        IsSelected = true;
        UpdateSelectionVisuals();
    }

    public void Deselect()
    {
        IsSelected = false;
        UpdateSelectionVisuals();
    }

    private void UpdateSelectionVisuals()
    {
        if(IsSelected) 
            spriteRenderer.material.color = Color.green;
        else
            spriteRenderer.material.color = Color.white;
    }
}
