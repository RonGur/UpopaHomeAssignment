using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public GameSettings gameSettings;
    public int PointsBonus { get; private set; }
    public int HealthBonus { get; private set; }

    private void Awake()
    {
        UseGameSettings();
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            PointsBonus = gameSettings.PickableItemPointsBonus;
            HealthBonus = gameSettings.PickableItemHealthBonus;
        }
    }

    private void OnMouseDown()
    {
        GameEvents.Instance.PickableItemActivated(this);
        Destroy(this.gameObject);
    }
}
