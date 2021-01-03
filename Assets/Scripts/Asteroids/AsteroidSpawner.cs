using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for spawning asteroids into the game
/// </summary>

public class AsteroidSpawner : MonoBehaviour
{
    public GameSettings gameSettings;
    private Camera cam;
    private float nextSpawnTime;
    private float spawnInterval = 3f;
    private float chanceToSpawnBlueAsteroid_inPrecents = 70;
    private float chanceToSpawnRedAsteroid_inPrecents = 20;

    [SerializeField] private AsteroidFactory asteroidFactory;
    [SerializeField] private Transform leftBorderTransform;
    [SerializeField] private Transform rightBorderTransform;
    [SerializeField] private Transform upperBorderTransform;
    [SerializeField] private Transform lowerBorderTransform;

    private void Awake()
    {
        UseGameSettings();
        cam = Camera.main;
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad >= nextSpawnTime)
        {
            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        nextSpawnTime = Time.timeSinceLevelLoad + spawnInterval;
        //Vector3 spawnPosition = new Vector3(Random.Range(leftBorderTransform.position.x, rightBorderTransform.position.x), Random.Range(lowerBorderTransform.position.y, upperBorderTransform.position.y), 0);
        Vector3 spawnPosition = GetSpawnPosition();
        float chance = Random.Range(1, 101);

        if (chance <= chanceToSpawnBlueAsteroid_inPrecents)
        {
            asteroidFactory.CreateBlueAsteroid(spawnPosition);
        }
        else if (chance <= chanceToSpawnBlueAsteroid_inPrecents + chanceToSpawnRedAsteroid_inPrecents)
        {
            asteroidFactory.CreateRedAsteroid(spawnPosition);
        }
        else
        {
            return;
        }
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            chanceToSpawnBlueAsteroid_inPrecents = gameSettings.ChanceToSpawnBlueAsteroid_inPrecents;
            chanceToSpawnRedAsteroid_inPrecents = gameSettings.ChanceToSpawnRedAsteroid_inPrecents;
            spawnInterval = gameSettings.AsteroidSpawnTimeInterval;
        }
    }

    private Vector3 GetSpawnPosition()
    {
        int chance = Random.Range(0, 4);
        float leftSideX = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float bottomSideY = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float rightSideX = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)).x;
        float upSideY = cam.ViewportToWorldPoint(new Vector3(1, 1, 0)).y;

        switch (chance)
        {
            case 0:
                return new Vector3(leftBorderTransform.position.x + 0.3f, Random.Range(bottomSideY, upSideY), 0);
            case 1:
                return new Vector3(rightBorderTransform.position.x - 0.3f, Random.Range(bottomSideY, upSideY), 0);
            case 2:
                return new Vector3(Random.Range(bottomSideY, upSideY), upperBorderTransform.position.y - 0.3f, 0);
            default:
                return new Vector3(Random.Range(bottomSideY, upSideY), lowerBorderTransform.position.y + 0.3f, 0);
        }

    }
}
