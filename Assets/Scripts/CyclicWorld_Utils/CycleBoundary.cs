using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleBoundary : MonoBehaviour
{
    public enum BoundType { Left, Right, Upper, Lower}
    public BoundType _boundType;

    private void OnTriggerEnter(Collider other)
    {
        SlaveHandler slaveHandler = other.GetComponent<SlaveHandler>();

        if (slaveHandler != null)
        {
            slaveHandler.OnSlaveHandlerEnteredBound(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        SlaveHandler slaveHandler = other.GetComponent<SlaveHandler>();

        if (slaveHandler != null)
        {
            slaveHandler.OnSlaveHandlerLeftBound(this);
        }
    }
}
