using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPixelSnapper : MonoBehaviour
{

    private Camera cam;
    private float leftRightPixelsOffset = 200;
    private float upDownPixelsOffset = 0;

    [SerializeField] private Side sideToSnapTo;

    public enum Side
    { Left, Right, Up, Down }

    public GameSettings gameSettings;

    private void Awake()
    {
        UseGameSettings();
        cam = Camera.main;
        Snap();
        
    }

    // Update is called once per frame
    private void Update()
    {
        Snap();
    }

    private void Snap()
    {
        switch (sideToSnapTo)
        {
            case Side.Left:
                transform.position = new Vector3(-ConvertToUnits(Screen.width / 2 - leftRightPixelsOffset), transform.position.y, transform.position.z);
                break;
            case Side.Right:
                transform.position = new Vector3(ConvertToUnits(Screen.width / 2 - leftRightPixelsOffset), transform.position.y, transform.position.z);
                break;
            case Side.Up:
                transform.position = new Vector3(ConvertToUnits(Screen.height / 2 - upDownPixelsOffset), transform.position.y, transform.position.z);
                break;
            case Side.Down:
                transform.position = new Vector3(-ConvertToUnits(Screen.height / 2 - upDownPixelsOffset), transform.position.y, transform.position.z);
                break;
        }
    }

    private float ConvertToUnits(float p)
    {
        float ortho = cam.orthographicSize;
        float pixelH = cam.pixelHeight;
        return (p * ortho * 2) / pixelH;
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            leftRightPixelsOffset = gameSettings.GreyBordersPixelsOffset;
        }
    }
}
