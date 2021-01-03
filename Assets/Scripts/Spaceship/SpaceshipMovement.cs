using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public GameSettings gameSettings;

    [SerializeField] private SpaceshipInputController spaceshipInputController;
    private Transform _transform;

    //Unity units in seconds
    private float rotationSpeed = 80f;
    private float rotationDragFactor = 2.5f;
    private float forwardSpeed = 2f;
    private float currentDrag;

    enum RotationDragState { None, Left, Right }
    RotationDragState _dragState;

    private void Awake()
    {
        UseGameSettings();
        _transform = GetComponent<Transform>();
        currentDrag = 0;
        _dragState = RotationDragState.None;
    }

    private void UseGameSettings()
    {
        if (gameSettings == null) return;

        rotationSpeed = gameSettings.RotationSpeed;
        rotationDragFactor = gameSettings.RotationDragFactor;
        forwardSpeed = gameSettings.ForwardSpeed;
    }

    private void Update()
    {
        _transform.Translate(_transform.up * Time.deltaTime * forwardSpeed, Space.World);

        if (spaceshipInputController.RotateLeft)
        {
            ResetDrag();
            RotateSpaceship(rotationSpeed);
        }

        if (spaceshipInputController.RotateRight)
        {
            ResetDrag();
            RotateSpaceship(-rotationSpeed);
        }

        if (spaceshipInputController.RotateDragRight)
        {
            _dragState = RotationDragState.Right;
        }
        if (spaceshipInputController.RotateDragLeft)
        {
            _dragState = RotationDragState.Left;
        }

        if (_dragState != RotationDragState.None)
            HandleRotationDrag();
    }

    private void ResetDrag()
    {
        _dragState = RotationDragState.None;
        currentDrag = 0;
    }

    private void HandleRotationDrag()
    {
        if ((rotationSpeed - currentDrag) <= 0)
        {
            ResetDrag();
            return;
        }

        currentDrag += rotationDragFactor;

        if (_dragState == RotationDragState.Left)
        {
            RotateSpaceship(rotationSpeed - currentDrag);
        }
        if (_dragState == RotationDragState.Right)
        {
            RotateSpaceship(-(rotationSpeed - currentDrag));
        }
    }

    private void RotateSpaceship(float speed)
    {
        _transform.Rotate(0, 0, speed * Time.deltaTime, Space.Self);
    }
}

