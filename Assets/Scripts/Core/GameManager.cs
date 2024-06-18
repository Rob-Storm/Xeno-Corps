using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState GameState { get; private set; } = GameState.Geoscape;

    public static GameObject ManagerGameObject {get; private set; }

    public delegate void GameStateChanged(object sender, StateEventArgs e);

    public static event GameStateChanged OnGameStateChanged;

    private void Awake()
    {
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

    public void GameStateTransition(GameState NewGameState)
    {
        GameState = NewGameState;

        switch (NewGameState)
        {
            case GameState.Geoscape:
                ManagerGameObject.AddComponent<GeoscapeCamera>();
                break;
            case GameState.Briefing:
                break;
            case GameState.BattleScape:
                ManagerGameObject.AddComponent<BattlescapeCamera>();
                break;
            default:
                Debug.LogWarning("No Valid GameState Set!");
                break;
        }

        OnGameStateChanged?.Invoke(this, new StateEventArgs(GameState));
    }

    public void SaveGame()
    {
        //todo: implement saving
    }
    public void LoadGame()
    {
        //todo: implement loading
    }
}

public enum GameState
{
    Geoscape,
    BattleScape,
    Briefing
}


public class StateEventArgs : EventArgs
{
    public GameState NewGameState { get; }

    public StateEventArgs(GameState GameState)
    {
        NewGameState = GameState;
    }
}