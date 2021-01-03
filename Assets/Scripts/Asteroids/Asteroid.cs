
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Asteroid game object, base class, meant to be inherited from different types of asteroids
/// </summary>
public abstract class Asteroid : MonoBehaviour, IGameObjectPooled
{
    public enum AsteroidType
    {
        Red, Blue
    }
    public AsteroidType Type { get; protected set; }

    protected GameObjectPool asteroidPool;

    public GameObjectPool Pool
    {
        get { return asteroidPool; }
        set
        {
            if (asteroidPool == null) asteroidPool = value;
            else throw new System.Exception("Bad pool use, this should only get set once - a pool should never change!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<SpaceshipHealthManager>() != null)
        {
            OnHitSpaceship(other.gameObject);
        }

        if (other.GetComponent<Bullet>() != null)
        {
            OnHitBullet();
        }
    }

    protected virtual void OnHitSpaceship(GameObject spaceship)
    {
        spaceship.GetComponent<SpaceshipHealthManager>().OnAsteroidHit();
    }

    // This is meant to be overridden by each unique asteroid inheriting 
    protected virtual void OnHitBullet()
    {
        KillAsteroid();
    }

    protected void KillAsteroid()
    {
        asteroidPool.ReturnToPool(this.gameObject);
    }



}
