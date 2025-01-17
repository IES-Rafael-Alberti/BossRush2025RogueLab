using UnityEngine;

public class bala : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    private Vector3 targetDirection;

    void Start()
    {
        // Obtén la dirección hacia el ratón en el mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Ajusta la distancia de la cámara
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcula la dirección hacia el ratón
        targetDirection = (worldMousePosition - transform.position).normalized;

        Destroy(gameObject, lifetime); // Destruir proyectil después de un tiempo
    }

    void Update()
    {
        // Mueve la bala en la dirección hacia el ratón desde el firePoint
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }
}
