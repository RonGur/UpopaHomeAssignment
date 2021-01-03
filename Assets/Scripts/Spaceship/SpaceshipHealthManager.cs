using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipHealthManager : MonoBehaviour
{
    public int SpaceshipHealth { get; private set; }
    public GameSettings gameSettings;

    private int maxHealth = 1000;
    private int healthInitialDecreaseRate = 1;
    private int healthDecreaseVal = 50;
    private int increaseHealthDecreaseInterval = 5;
    private int healthDecreaseAmount = 5;
    private float healthDecreaseRate;
    private float timeToNextHealthDecrease;
    private float timeToNextRateIncrease;
   
    private void Start()
    {
        GameEvents.Instance.OnPickableItemActivated += OnPickableItemActivated;
        UseGameSettings();
        timeToNextHealthDecrease = 0;
        timeToNextRateIncrease = 0;
        SpaceshipHealth = maxHealth;
        timeToNextRateIncrease = increaseHealthDecreaseInterval;
        healthDecreaseRate = healthInitialDecreaseRate;
    }

    private void UseGameSettings()
    {
        if (gameSettings == null) return;

        maxHealth = gameSettings.MaxHealth;
        healthInitialDecreaseRate = gameSettings.HealthInitialDecreaseRate;
        healthDecreaseVal = gameSettings.HealthDecreaseVal;
        increaseHealthDecreaseInterval = gameSettings.IncreaseHealthDecreaseInterval;
        healthDecreaseAmount = gameSettings.HealthDecreaseAmount; 
    }

    private void OnPickableItemActivated(PickableItem pickableItem)
    {
        ChangeHealth(SpaceshipHealth + pickableItem.HealthBonus);
    }

    private void Update()
    {
        if (Time.timeSinceLevelLoad > timeToNextHealthDecrease)
        {
            timeToNextHealthDecrease += healthDecreaseRate;
            ChangeHealth(Mathf.Clamp(SpaceshipHealth - healthDecreaseVal, 0, maxHealth));
        }

        if (Time.timeSinceLevelLoad > timeToNextRateIncrease)
        {
            timeToNextRateIncrease += increaseHealthDecreaseInterval;
            healthDecreaseVal += healthDecreaseAmount;
        }
    }

    private void ChangeHealth(int newHealth)
    {
        SpaceshipHealth = newHealth;
        GUIManager.Instance.UpdateHealthBar(SpaceshipHealth);

        if (SpaceshipHealth <= 0)
        {
            GameEvents.Instance.PlayerDied();
        }
    }

    public void OnAsteroidHit()
    {
        GameEvents.Instance.PlayerDied();
        Destroy(gameObject);
    }
}
