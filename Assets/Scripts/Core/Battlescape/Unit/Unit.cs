using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private bool IsSelected { get; set; } = false;

    [SerializeField] private SpriteRenderer renderer;

    private void Awake()
    {
        //renderer = GetComponent<SpriteRenderer>();
    }

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
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.white;
    }
}
