using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance { get; private set; }

    [SerializeField] private LayerMask unitLayerMask;

    private Unit selectedUnit;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Update()
    {
        HandleUnitSelection();
    }

    private void HandleUnitSelection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Ray ray = 
        }
    }

    private void SelectUnit(Unit unit)
    {
        if (selectedUnit != null)
        {
            selectedUnit.Deselect();
        }

        selectedUnit = unit;
        selectedUnit.Select();
    }
}
