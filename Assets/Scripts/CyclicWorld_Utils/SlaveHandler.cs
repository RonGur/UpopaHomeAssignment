using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles "slave" mechanism to create 'cycle world' effect 
/// </summary>
public class SlaveHandler : MonoBehaviour
{
    private GameObject slave;
    private Transform slaveTransform;
    private Vector3 distancFromSlave;
    private float xDistance;
    private float yDistance;

    [SerializeField] private GameObject slavePrefab;
    [SerializeField] private Transform leftBorderTransform;
    [SerializeField] private Transform rightBorderTransform;
    [SerializeField] private Transform upperBorderTransform;
    [SerializeField] private Transform lowerBorderTransform;



    private void Start()
    {
        CycleBoundary[] borders = FindObjectsOfType<CycleBoundary>();
        foreach (CycleBoundary border in borders)
        {
            switch (border._boundType)
            {
                case CycleBoundary.BoundType.Left:
                    leftBorderTransform = border.transform;
                    break;
                case CycleBoundary.BoundType.Right:
                    rightBorderTransform = border.transform;
                    break;
                case CycleBoundary.BoundType.Upper:
                    upperBorderTransform = border.transform;
                    break;
                case CycleBoundary.BoundType.Lower:
                    lowerBorderTransform = border.transform;
                    break;
            }
        }

        distancFromSlave = Vector3.zero;
        slave = Instantiate(slavePrefab);
        slave.SetActive(false);
        slave.transform.localScale = transform.localScale;
        slaveTransform = slave.transform;
    }

    void Update()
    {
        if (slave != null && slave.activeInHierarchy)
        {
            slaveTransform.position = transform.position + distancFromSlave;
            slaveTransform.rotation = transform.rotation;
        }
    }

    public void OnSlaveHandlerEnteredBound(CycleBoundary boundary)
    {
        // in case the border position has changed due to aspect ratio changes
        GetBorderDistance();

        slave.SetActive(true);

        switch (boundary._boundType)
        {
            case CycleBoundary.BoundType.Left:
                distancFromSlave = new Vector3(xDistance, 0, 0);
                break;
            case CycleBoundary.BoundType.Right:
                distancFromSlave = new Vector3(-xDistance, 0, 0);
                break;
            case CycleBoundary.BoundType.Upper:
                distancFromSlave = new Vector3(0, -yDistance, 0);
                break;
            case CycleBoundary.BoundType.Lower:
                distancFromSlave = new Vector3(0, yDistance, 0);
                break;
        }
    }

    private void GetBorderDistance()
    {
        xDistance = Vector3.Distance(rightBorderTransform.position, leftBorderTransform.position);
        yDistance = Vector3.Distance(upperBorderTransform.position, lowerBorderTransform.position);
    }

    public void OnSlaveHandlerLeftBound(CycleBoundary boundary)
    {

        slave.SetActive(false);
        if ((boundary._boundType == CycleBoundary.BoundType.Left) && (transform.right.y > 0))
        {
            transform.position += new Vector3(xDistance, 0, 0);
        }

        if ((boundary._boundType == CycleBoundary.BoundType.Right) && (transform.right.y < 0))
        {
            transform.position += new Vector3(-xDistance, 0, 0);
        }

        if ((boundary._boundType == CycleBoundary.BoundType.Upper) && (transform.up.y > 0))
        {
            transform.position += new Vector3(0, -yDistance, 0);
        }

        if ((boundary._boundType == CycleBoundary.BoundType.Lower) && (transform.up.y < 0))
        {
            transform.position += new Vector3(0, yDistance, 0);
        }
    }

    public void OnDestroy()
    {
        Destroy(slave);
    }
}
