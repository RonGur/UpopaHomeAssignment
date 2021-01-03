using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IGameObjectPooled
{
    public GameSettings gameSettings;

    private float moveSpeed = 10f;
    private float lifeTime;
    private float maxLifeTime = 3f;
    private GameObjectPool pool;


    private void Awake()
    {
        UseGameSettings();
    }

    public GameObjectPool Pool
    {
        get { return pool; }
        set
        {
            if (pool == null) pool = value;
            else throw new System.Exception("Bad pool use, this should only get set once - a pool should never change!");
        }
    }

    private void OnEnable()
    {
        lifeTime = 0f;
    }

    private void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * moveSpeed, Space.World);
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            pool.ReturnToPool(this.gameObject);
        }
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            moveSpeed = gameSettings.BulletSpeed;
            maxLifeTime = gameSettings.BulletLifeTime;
        }
    }
}
