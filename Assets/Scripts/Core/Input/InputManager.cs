using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    private PlayerActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerActions();
        inputActions.Camera.Enable();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }

    public bool GetCanPanCamera()
    {
        return inputActions.Camera.PanToggle.IsPressed();
    }

    public Vector2 GetMouseDelta()
    {
        return inputActions.Camera.Pan.ReadValue<Vector2>();
    }
}
