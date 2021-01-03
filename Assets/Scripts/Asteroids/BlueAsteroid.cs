using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueAsteroid : Asteroid
{
    public GameSettings gameSettings;

    [SerializeField] private SimplePrefabSpawner pickableItemSpawner;
    private int chanceToGetPickableInPercents = 50;

    private void Awake()
    {
        UseGameSettings();

        Type = AsteroidType.Blue;
        chanceToGetPickableInPercents = Mathf.Clamp(chanceToGetPickableInPercents, 0, 100);
    }

    protected override void OnHitBullet()
    {
        float chance = Random.Range(1, 101);
        if (chance <= chanceToGetPickableInPercents)
        {
            SpawnPickable();
        }
        KillAsteroid();
    }

    private void SpawnPickable()
    {
        pickableItemSpawner.SpawnPrefab(transform.position);
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            chanceToGetPickableInPercents = gameSettings.ChanceToGetPickable_inPercents;
        }
    }
}
