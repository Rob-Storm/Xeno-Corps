using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitSelectionManager : Singleton<UnitSelectionManager>
{
    public static UnitSelectionManager Instance { get; private set; }

    [SerializeField] private LayerMask unitLayerMask;

    private Unit selectedUnit;
    private int selectedIndex;

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

    private void Start()
    {
        SelectUnit(BattlescapeManager.Instance.Units[0]);
        selectedIndex = 0;
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
            if( selectedIndex >= BattlescapeManager.Instance.Units.Count)
                selectedIndex = 0;

            SelectUnit(BattlescapeManager.Instance.Units[selectedIndex]);
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

        Debug.Log($"Selected Unit: {selectedUnit}|{selectedIndex}");
    }
}
