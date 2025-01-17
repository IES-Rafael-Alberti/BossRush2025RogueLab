using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovem : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;

    private CharacterController characterController;
    private Animator animator;
    public float jumpForce = 5f; // Fuerza del salto
    public float gravity = -9.8f; // Gravedad personalizada
    private Vector3 velocity; // Velocidad vertical
    private bool isGrounded; // Verificar si está en el suelo

    void Start()
    {
        // Obtén referencias al CharacterController y al Animator
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
         isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Resetear la velocidad vertical al tocar el suelo
        }
        // Obtener entrada del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        // Mover al personaje
        if (movement.magnitude > 0.1f)
        {
            // Rotación hacia la dirección del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Mover al personaje
            characterController.Move(movement * speed * Time.deltaTime);
        }

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover al jugador según la velocidad vertical
        characterController.Move(velocity * Time.deltaTime);

        // Configurar el parámetro de velocidad para animaciones
        Debug.Log(movement.magnitude); 
        animator.SetFloat("Speed", movement.magnitude);
    }
}
