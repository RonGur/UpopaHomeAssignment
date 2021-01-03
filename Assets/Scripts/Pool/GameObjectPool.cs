using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : MonoBehaviour
{
    public int Instantiated { get; private set; }
    [SerializeField] private GameObject prefab;
    private Queue<GameObject> objects = new Queue<GameObject>();

    private void Awake()
    {
        Instantiated = 0;
    }

    public GameObject Get()
    {
        if (objects.Count == 0)
            AddObjects(1);
        return objects.Dequeue();
    }

    public void ReturnToPool(GameObject objectToReturn)
    {
        objectToReturn.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    private void AddObjects(int count)
    {
        GameObject newObject = Instantiate(prefab);
        Instantiated++;
        newObject.SetActive(false);
        objects.Enqueue(newObject);
        newObject.GetComponent<IGameObjectPooled>().Pool = this;
    }
}
