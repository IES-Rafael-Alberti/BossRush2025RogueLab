using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public Vector3 rotationSpeed = new Vector3(0, 50, 0); // Velocidad de rotación en cada eje

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
