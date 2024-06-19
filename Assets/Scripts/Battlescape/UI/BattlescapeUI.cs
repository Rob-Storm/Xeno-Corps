using TMPro;
using UnityEngine;

public class BattlescapeUI : MonoBehaviour
{
    public TMP_Text AgentNameText;
    public TMP_Text TimeUnitsText;

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
}
