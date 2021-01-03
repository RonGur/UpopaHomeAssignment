using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all game events (Actions) 
/// and all are registered and triggered via this object and could be managed easily that way
/// on bigger scale games - I would split this class to smaller ones - "input events" , "spaceship events" etc...
/// </summary>

public class GameEvents : MonoBehaviour
{
    // there should be only one instance at all time, and should be reachable from all
    public static GameEvents Instance { get; private set; }
    public event Action<CycleBoundary, SlaveHandler> OnSlaveHandlerEnteredBound;
    public event Action<CycleBoundary, SlaveHandler> OnSlaveHandlerLeftBound;
    public event Action OnShotTriggered;
    public event Action<PickableItem> OnPickableItemActivated;
    public event Action OnPlayerDied;

    private void Awake()
    {
        // Singleton init
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void SlaveHandlerEnteredBound(CycleBoundary boundary, SlaveHandler slaveHandler)
    {
        OnSlaveHandlerEnteredBound?.Invoke(boundary, slaveHandler);
    }

    public void SlaveHandlerLeftBound(CycleBoundary boundary, SlaveHandler slaveHandler)
    {
        OnSlaveHandlerLeftBound?.Invoke(boundary, slaveHandler);
    }

    public void ShotTriggered()
    {
        OnShotTriggered?.Invoke();
    }

    public void PickableItemActivated(PickableItem pickableItem)
    {
        OnPickableItemActivated?.Invoke(pickableItem);
    }

  public void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }
}