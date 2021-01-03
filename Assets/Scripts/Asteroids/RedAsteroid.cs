using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAsteroid : Asteroid
{
    public GameSettings gameSettings;

    private float explosionRadius;
    private float explosionRadiusMultiplyer = 3;
    
    private void Start()
    {
        UseGameSettings();

        Type = AsteroidType.Red;
        explosionRadius = GetComponent<SphereCollider>().radius * explosionRadiusMultiplyer;
    }

    private void UseGameSettings()
    {
        if (gameSettings)
        {
            explosionRadiusMultiplyer = gameSettings.RedAsteroidExplosionMultiplier;
        }
    }

    protected override void OnHitBullet()
    {
        Explode();
    }

    private void Explode()
    {
        // don't explode if you are a slave (as requested in the design)
        if (!GetComponent<SlaveHandler>()) return;
        CreateExplosionSphere();
        KillAsteroid();
    }

    private void CreateExplosionSphere()
    {
        GameObject explosionSphere = new GameObject("ExplosionSphere", typeof(SphereCollider));
        explosionSphere.transform.localScale = transform.localScale;
        explosionSphere.transform.position = transform.position;
        explosionSphere.GetComponent<SphereCollider>().radius = GetComponent<SphereCollider>().radius * 3;
        explosionSphere.GetComponent<SphereCollider>().isTrigger = true;
        explosionSphere.AddComponent<RedAsteroidExplosion>();
    }

    public void OnEnteredExplosion()
    {
        CreateExplosionSphere();
    }
}
