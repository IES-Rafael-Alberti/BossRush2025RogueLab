using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;
    public float lifetime = 5f;

    private Vector3 targetDirection;

    void Start()
    {
        // Obt�n la direcci�n hacia el rat�n en el mundo
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 15f; // Ajusta la distancia de la c�mara
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calcula la direcci�n hacia el rat�n
        targetDirection = (worldMousePosition - transform.position).normalized;

        Destroy(gameObject, lifetime); // Destruir proyectil despu�s de un tiempo
    }

    void Update()
    {
        // Mueve la bala en la direcci�n hacia el rat�n desde el firePoint
        transform.Translate(targetDirection * speed * Time.deltaTime);
    }
}
