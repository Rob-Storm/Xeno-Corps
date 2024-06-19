using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ObjectBase> Inventory;

    [SerializeField] private ObjectBase LeftHand, RightHand;

    [SerializeField] private Unit Unit;


    private void Awake()
    {
        Unit = GetComponent<Unit>();
    }

    public List<ObjectBase> GetInventory()
    {
        return Inventory;
    }

    public void AddItem(ObjectBase Item)
    {
        if (GetWeight() >= Unit.GetStats().Stamina)
        {
            Debug.Log("Not enough space!");
        }
        else
            Inventory.Add(Item);
    }

    private int GetWeight()
    {
        int currentWeight = 0;

        foreach (ObjectBase Item in Inventory)
        {
            currentWeight += Item.Weight;
        }

        return currentWeight;
    }

    public void ClearList()
    {
        Inventory.Clear();
    }

}
