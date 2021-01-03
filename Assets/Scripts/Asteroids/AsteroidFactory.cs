using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages creation of asteroids
/// </summary>

public class AsteroidFactory : MonoBehaviour
{
    public GameSettings gameSettings;
    private int maxAsteroidsAmount = 20;
    [SerializeField] private GameObjectPool RedAsteroidPool;
    [SerializeField] private GameObjectPool BlueAsteroidPool;

    private void Start()
    {
        UseGameSettings();
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            maxAsteroidsAmount = gameSettings.MaxAsteroidsAmount;
        }
    }

    public void CreateRedAsteroids(List<Vector3> spawnPoints)
    {
        Create(RedAsteroidPool, spawnPoints);
    }

    public void CreateBlueAsteroids(List<Vector3> spawnPoints)
    {
        Create(BlueAsteroidPool, spawnPoints);
    }

    // Wrapper for a single point (I know it's not so elegant and bit more space consuming but I want the code to stay clean and simple
    // obviously it's no problem to use 2 different methods (one that takes a list and one that takes a vector point

    public void CreateRedAsteroid(Vector3 spawnPoint)
    {
        List<Vector3> spawnPointList = new List<Vector3>();
        spawnPointList.Add(spawnPoint);
        Create(RedAsteroidPool, spawnPointList);
    }

    public void CreateBlueAsteroid(Vector3 spawnPoint)
    {
        List<Vector3> spawnPointList = new List<Vector3>();
        spawnPointList.Add(spawnPoint);
        Create(BlueAsteroidPool, spawnPointList);
    }

    // I understand that currently that game doesn't need to spawn multiple asteroids at the same time
    //but as a force of habit and for the sake of scalability I decided to keep it like this 
    void Create(GameObjectPool pool, List<Vector3> spawnPoints)
    {
        if (pool.Instantiated >= maxAsteroidsAmount)
        {
            print(pool.Instantiated);
            Debug.Log("asteroid pool size has exceeded limit");
            return;
        }

        for (int i = 0; i < spawnPoints.Count; i++)
        {
            GameObject spawnedAsteroid = pool.Get();
            spawnedAsteroid.SetActive(true);
            Asteroid asteroid = spawnedAsteroid.GetComponent<Asteroid>();
            asteroid.transform.position = spawnPoints[i];
            asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 364));
        }
    }
}
