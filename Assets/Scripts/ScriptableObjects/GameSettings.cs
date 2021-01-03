using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameSettings")]
public class GameSettings : ScriptableObject
{
    [Header("Input settings")]
    [SerializeField] private KeyCode rotateRightKey = KeyCode.A;
    [SerializeField] private KeyCode fireKey = KeyCode.Space;
    [SerializeField] private KeyCode rotateLeftKey = KeyCode.D;

    [Header("Spaceship Health settings")]
    [SerializeField] private int maxHealth = 1000;
    [SerializeField] private int healthInitialDecreaseRate = 1;
    [SerializeField] private int healthDecreaseVal = 50;
    [SerializeField] private int increaseHealthDecreaseInterval = 5;
    [SerializeField] private int healthDecreaseAmount = 5;

    [Header("Spaceship Movement settings")]
    [SerializeField] private float rotationSpeed = 80f;
    [SerializeField] private float rotationDragFactor = 2.5f;
    [SerializeField] private float forwardSpeed = 2f;

    [Header("Asteroids settings")]
    [SerializeField] private float asteroidMovementSpeed= 2f;
    [SerializeField] private float redAsteroidExplosionMultiplier = 3;
    [SerializeField] private int chanceToGetPickable_inPercents = 50;
    [SerializeField] private float chanceToSpawnBlueAsteroid_inPrecents = 70;
    [SerializeField] private float chanceToSpawnRedAsteroid_inPrecents = 20;
    [SerializeField] private float asteroidSpawnTimeInterval = 0.5f;
    [SerializeField] private int maxAsteroidsAmount = 20;

    [Header("UI settings")]
    [SerializeField] private float greyBordersPixelsOffset = 200;

    [Header("Bullet settings")]
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLifeTime = 3f;

    [Header("PickableItem settings")]
    [SerializeField] private int pickableItemHealthBonus = 1000;
    [SerializeField] private int pickableItemPointsBonus = 50;


    public KeyCode RotateRightKey { get { return rotateRightKey; }}
    public KeyCode RotateLeftKey { get { return rotateLeftKey; } }
    public KeyCode FireKey { get { return fireKey; } }
    public int MaxHealth { get { return maxHealth; } }
    public int HealthInitialDecreaseRate { get { return healthInitialDecreaseRate; } }
    public int HealthDecreaseVal { get { return healthDecreaseVal; } }
    public int IncreaseHealthDecreaseInterval { get { return increaseHealthDecreaseInterval; } }
    public int HealthDecreaseAmount { get { return healthDecreaseAmount; } }
    public float RotationSpeed { get { return rotationSpeed;  } }
    public float RotationDragFactor { get { return rotationDragFactor; } }
    public float ForwardSpeed { get { return forwardSpeed; } }
    public float AsteroidMovementSpeed { get { return asteroidMovementSpeed; } }
    public float RedAsteroidExplosionMultiplier{ get { return redAsteroidExplosionMultiplier; } }
    public int ChanceToGetPickable_inPercents { get { return chanceToGetPickable_inPercents; } }
    public float ChanceToSpawnBlueAsteroid_inPrecents { get { return chanceToSpawnBlueAsteroid_inPrecents; } }
    public float ChanceToSpawnRedAsteroid_inPrecents { get { return chanceToSpawnRedAsteroid_inPrecents; } }
    public float AsteroidSpawnTimeInterval { get { return asteroidSpawnTimeInterval; } }
    public int MaxAsteroidsAmount { get { return maxAsteroidsAmount; } }
    public float GreyBordersPixelsOffset { get { return greyBordersPixelsOffset; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    public float BulletLifeTime { get { return bulletLifeTime; } }
    public int PickableItemHealthBonus { get { return pickableItemHealthBonus; } }
    public int PickableItemPointsBonus { get { return pickableItemPointsBonus; } }



}
