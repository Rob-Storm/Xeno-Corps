using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState GameState { get; private set; } = GameState.Geoscape;

    public GameObject ManagerGameObject {get; private set; }

    public delegate void GameStateChanged(object sender, StateEventArgs e);

    public event GameStateChanged OnGameStateChanged;

    public void GameStateTransition(GameState NewGameState)
    {
        GameState = NewGameState;
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