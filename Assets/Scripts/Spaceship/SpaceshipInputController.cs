using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpaceshipInputController : MonoBehaviour
{
    public GameSettings gameSettings;

    public bool RotateRight { get; protected set; }
    public bool RotateLeft { get; protected set; }
    public bool RotateDragRight { get; protected set; }
    public bool RotateDragLeft { get; protected set; }
    public Action OnShootTriggered;

    private KeyCode rotateRightKey = KeyCode.D;
    private KeyCode rotateLeftKey = KeyCode.A;
    private KeyCode fireKey = KeyCode.Space;

    private void Start()
    {
        UseGameSettings();
    }

    private void UseGameSettings()
    {
        if (gameSettings == null) return;

        rotateRightKey = gameSettings.RotateRightKey;
        rotateLeftKey = gameSettings.RotateLeftKey;
        fireKey = gameSettings.FireKey;
    }

    void Update()
    {
        RotateRight = Input.GetKey(rotateRightKey);
        RotateLeft = Input.GetKey(rotateLeftKey);
        RotateDragRight = Input.GetKeyUp(rotateRightKey);
        RotateDragLeft = Input.GetKeyUp(rotateLeftKey);

        if (Input.GetKeyDown(fireKey))
            GameEvents.Instance.ShotTriggered();
    }
}
