using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerActions();
        inputActions.Camera.Enable();
        inputActions.GeoShortcuts.Enable();
        inputActions.BatShortcuts.Disable();
    }

    private void OnEnable()
    {
        GameManager.Instance.OnGameStateChanged += Instance_OnGameStateChanged;
    }

    private void Instance_OnGameStateChanged(object sender, StateEventArgs e)
    {
        switch (e.NewGameState)
        {
            case GameState.Geoscape:
                inputActions.GeoShortcuts.Enable();
                inputActions.BatShortcuts.Disable();
                break;
            case GameState.Briefing:
                inputActions.GeoShortcuts.Disable();
                inputActions.BatShortcuts.Disable();
                break;
            case GameState.BattleScape:
                inputActions.GeoShortcuts.Disable();
                inputActions.BatShortcuts.Enable();
                break;
            default:
                Debug.LogWarning("No Valid GameState Set!");
                break;
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
