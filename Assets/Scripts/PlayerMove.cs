using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller; // Referencia al CharacterController
    public float speed = 5f; // Velocidad de movimiento
    public float jumpForce = 5f; // Fuerza del salto
    public float gravity = -9.8f; // Gravedad personalizada

    private Vector3 velocity; // Velocidad vertical
    private bool isGrounded; // Verificar si está en el suelo

    void Update()
    {
        // Verificar si está en el suelo
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resetear la velocidad vertical al tocar el suelo
        }

        // Movimiento horizontal (usar teclas W, A, S, D o flechas)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover al jugador según la velocidad vertical
        controller.Move(velocity * Time.deltaTime);
    }
}
