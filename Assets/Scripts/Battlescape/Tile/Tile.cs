using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;

    public void Damage(int amount)
    {
        health  -= amount;
        if (health <= 0)
            Die();
    }

    private void Die()
    {

    }
}
