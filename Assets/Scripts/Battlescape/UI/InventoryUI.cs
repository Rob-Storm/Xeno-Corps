using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text AgentNameText;


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
        AgentNameText.text = $"{e.Unit.Name}'s Inventory";
    }
}
