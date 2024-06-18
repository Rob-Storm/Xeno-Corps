using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private bool  IsSelected { get; set; }

    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void Select()
    {
        IsSelected = true;
        
    }

    public void Deselect()
    {

    }

    private void UpdateSelectionVisuals()
    {
        if(IsSelected) 
            renderer.material.color = Color.green;
        else
            renderer.material.color = Color.white;
    }
}
