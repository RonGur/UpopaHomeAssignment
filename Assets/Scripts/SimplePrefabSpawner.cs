using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple 'black box' object that creates a prefab
public class SimplePrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;

    public void SpawnPrefab(Vector3 spawnPosition)
    {
        GameObject spawnedPrefab = Instantiate(prefabToSpawn);
        spawnedPrefab.transform.position = spawnPosition;
    }
}
