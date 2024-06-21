using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlescapeManager : Singleton<BattlescapeManager>
{
    [SerializeField] private List<GameObject> Units;
    [SerializeField] private GameObject unitPrefab;
    private Vector2 spawnPosition;
    int XCOMAgents = 4;

    public event EventHandler OnFinishedSpawning;

    protected override void Awake()
    {
        base.Awake();
        Units = new List<GameObject>();
    }

    private void Start()
    {
        spawnPosition = new Vector2 (0, 0.15f);
        for(int i = 0; i < XCOMAgents; i++)
        {
            GameObject newUnit = Instantiate<GameObject>(unitPrefab, spawnPosition, Quaternion.identity);
            if (spawnPosition.x == 1)
            {
                spawnPosition.x = 0;
                spawnPosition.y -= 1f;
            }
                
            else
                spawnPosition.x += 1;

            Units.Add(newUnit);
        }

        OnFinishedSpawning?.Invoke(this, null);
    }

    public List<GameObject> GetUnits()
    {
        return Units;
    }
}
