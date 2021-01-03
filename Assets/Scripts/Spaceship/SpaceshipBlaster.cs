using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipBlaster : MonoBehaviour
{
    [SerializeField] private GameObjectPool gameObjectPool;

    private void Start()
    {
        GameEvents.Instance.OnShotTriggered += Fire;
    }

    private void Fire()
    {
        var shot = gameObjectPool.Get();
        shot.transform.position = transform.position;
        shot.transform.rotation = transform.rotation;
        shot.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameEvents.Instance.OnShotTriggered -= Fire;
    }
}
