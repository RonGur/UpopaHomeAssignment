using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component is added to the explosion created by a red asteroid
/// </summary>
public class RedAsteroidExplosion : MonoBehaviour
{
    private float lifeTime = 0.1f;

    private void Start()
    {
        StartCoroutine(Die());
    }

    void OnTriggerEnter(Collider other)
    {
        RedAsteroid redAsteroid = other.GetComponent<RedAsteroid>();
        if(redAsteroid != null)
        {
            redAsteroid.OnEnteredExplosion();
        }
    }

        IEnumerator Die()
    {
        yield return new WaitForSeconds(lifeTime); 
        Destroy(gameObject); 
    }
}
