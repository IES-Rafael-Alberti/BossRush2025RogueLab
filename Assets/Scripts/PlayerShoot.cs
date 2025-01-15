using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil

    public float fireRate = 0.5f; // Tiempo entre disparos
    public float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Crear proyectil en el firePoint
        Instantiate(projectilePrefab);
    }
}
