using TMPro;
using UnityEngine;

public class BattlescapeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text AgentNameText;
    [SerializeField] private TMP_Text TimeUnitsText;

    [SerializeField] private GameObject InventoryUI;

    private void OnEnable()
    {
        UnitSelectionManager.Instance.OnSelectedUnitChanged += Instance_OnSelectedUnitChanged;
    }

    private void OnDisable()
    {
        UnitSelectionManager.Instance.OnSelectedUnitChanged -= Instance_OnSelectedUnitChanged;
    }

    private void Instance_OnSelectedUnitChanged(object sender, UnitEventArgs e)
    {
        AgentNameText.text = e.Unit.Name;
        TimeUnitsText.text = $"Time Units: {e.Unit.TimeUnits}/{e.Unit.GetStats().TimeUnits}";
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
    }
}
