using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public GameSettings gameSettings;
    private Vector3 direction;
    private Transform _transform;
    private float speed = 1f;

    private void Awake()
    {
        UseGameSettings();
        _transform = transform;
        _transform.localRotation = Quaternion.Euler(0, 0, Random.Range(0, 364)); ;
    }

    private void UseGameSettings()
    {
        if (gameSettings == null) return;
        speed = gameSettings.AsteroidMovementSpeed;
    }

    private void Update()
    {
        _transform.Translate(_transform.up * Time.deltaTime * speed, Space.World);
    }
}
