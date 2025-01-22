using System;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI

public class IMG { 
    public bool isImageVisible = false;
    public Image image;
    public IMG(bool isVisible, Image image)
    {
        isImageVisible = isVisible;
        this.image = image;
    }
    public IMG(bool isVisible)
    {
        isImageVisible = isVisible;
    }
}
public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint;         // Punto de disparo
    public CharacterController characterController;
    public Transform eniemiPosition;

    public Image img1;
    public Image img2;     // Imagen que se mostrará al disparar

    private IMG shootImage = new IMG(false);

    private IMG shootImage2 = new IMG(false);

    public float displayTime = 0.5f;    // Tiempo que la imagen estará visible
   

    private bool parry = false;
    private float playerLife = 10;

    public float fireRate = 0.5f;       // Tiempo entre disparos
    private float nextFireTime = 0f;

    void Update()
    {
        shootImage.image = img1;
        shootImage2.image = img2;

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && characterController.isGrounded)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }

        // Ocultar la imagen después de un tiempo
        if (shootImage.isImageVisible && Time.time > nextFireTime - fireRate + displayTime)
        {
            HideShootImage(shootImage);
            ShowShootImage(shootImage2);
        }
        // Ocultar la imagen después de un tiempo
        if (shootImage2.isImageVisible && Time.time > nextFireTime - fireRate + displayTime)
        {
            HideShootImage(shootImage2);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetButton("Parry"))
        {
            parry = true;
        }
        if (!(collision.gameObject.CompareTag("EnemyBullet") && !parry))
        {
            collision.rigidbody.AddForce(eniemiPosition.position * 5, ForceMode.Impulse);
        }
    }

    public bool IsParrying()
    {
        return parry;
    }

    void Shoot()
    {
        // Crear proyectil en el firePoint
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Mostrar la imagen
        ShowShootImage(shootImage);
    }

    void ShowShootImage(IMG image)
    {
        if (image != null)
        {
            image.image.enabled = true;
            image.isImageVisible = true;
        }
    }

    void HideShootImage(IMG image)
    {
        if (image != null)
        {
            image.image.enabled = false;
            image.isImageVisible = false;
        }
    }
}
