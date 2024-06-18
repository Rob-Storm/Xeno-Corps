using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState GameState { get; private set; } = GameState.Geoscape;

    public static GameObject ManagerGameObject {get; private set; }

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

    public void TransitionToGeoscape()
    {
        GameState = GameState.Geoscape;
        ManagerGameObject.AddComponent<GeoscapeCamera>();
    }

    public void TransitionToBattleScape()
    {
        GameState = GameState.BattleScape;
        ManagerGameObject.AddComponent<BattlescapeCamera>();
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
    BattleScape
}
