using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : SceneSingleton<UnitSelectionManager>
{
    [SerializeField] private LayerMask unitLayerMask;

    private Unit selectedUnit;
    private int selectedIndex;

    private List<IObserver<Unit>> observers = new List<IObserver<Unit>>();

    public delegate void SelectedUnitChanged(object sender, UnitEventArgs e);

    public event SelectedUnitChanged OnSelectedUnitChanged;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    private void OnEnable()
    {
        BattlescapeManager.Instance.OnFinishedSpawning += Instance_OnFinishedSpawning;
    }

    private void OnDisable()
    {
        BattlescapeManager.Instance.OnFinishedSpawning -= Instance_OnFinishedSpawning;
    }

    private void Instance_OnFinishedSpawning(object sender, EventArgs e)
    {
        selectedIndex = 0;
        SelectUnit(BattlescapeManager.Instance.GetUnits()[selectedIndex].GetComponent<Unit>());
    }

    private void Update()
    {
        HandleUnitSelection();
    }

    private void HandleUnitSelection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = BattlescapeCamera.Instance.Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, unitLayerMask))
            {
                Unit unit = hit.collider.gameObject.GetComponent<Unit>();
                if(unit != null)
                {
                    SelectUnit(unit);
                    Debug.Log($"Selected Unit: {unit.name}");
                }
                else
                    Debug.Log($"No unit selected");
            }
            Debug.Log($"Nothing there");
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            selectedIndex++;
            if( selectedIndex >= BattlescapeManager.Instance.GetUnits().Count)
                selectedIndex = 0;

            SelectUnit(BattlescapeManager.Instance.GetUnits()[selectedIndex].GetComponent<Unit>());
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

        BattlescapeCamera.Instance.Camera.transform.position = new Vector3(selectedUnit.transform.position.x, selectedUnit.transform.position.y, -10);

        OnSelectedUnitChanged?.Invoke(this, new UnitEventArgs(unit));
    }
}


public class UnitEventArgs : EventArgs
{
    public Unit Unit;

    public UnitEventArgs(Unit unit)
    {
        Unit = unit;
    }
}