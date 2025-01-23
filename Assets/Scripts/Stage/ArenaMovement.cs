using UnityEngine;

public class ArenaMovement : MonoBehaviour
{

    private Vector3 rotationSpeed = new Vector3(0, 0, 0); // Velocidad de rotación en cada eje
    private bool right = true;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            right = true;
        }
        else if (horizontalInput < 0)
        {
            right = false;
        }

        if (right)
        {
            rotationSpeed.y = 50;
        }
        else if (!right)
        {
            rotationSpeed.y = -50;
        }

        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
