using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlescapeManager : Singleton<BattlescapeManager>
{
    public List<Unit> Units;
    [SerializeField] private GameObject unitPrefab;
    private Vector2 spawnPosition;

    private void Start()
    {
        spawnPosition = new Vector2 (0, 0.15f);
        for(int i = 0; i < Units.Count; i++)
        {
            Instantiate(unitPrefab, new Vector3(spawnPosition.x, spawnPosition.y, 0f), Quaternion.identity);
            if (spawnPosition.x == 1)
            {
                spawnPosition.x = 0;
                spawnPosition.y -= 1f;
            }
                
            else
                spawnPosition.x += 1;
        }
    }
}
