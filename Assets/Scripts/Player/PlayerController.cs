using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f;

    private CharacterController characterController;
    [SerializeField] private int flashNumbers;
    [SerializeField] private GameManager gameManager;
    private PlayerShoot playerShoot;

    private Animator animator;

    public float jumpForce = 5f; // Fuerza del salto
    public float gravity = -9.8f; // Gravedad personalizada
    private Vector3 velocity; // Velocidad vertical
    private bool isGrounded; // Verificar si est� en el suelo
    private bool right = true;
    float velocHorizontal = 1;

    void Start()
    {
        // Obt�n referencias al CharacterController y al Animator
        characterController = GetComponent<CharacterController>();
        playerShoot = GetComponent<PlayerShoot>();
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
        
        if (horizontal > 0)
        {
            right = true;
            velocHorizontal = 1;
        }
        else if (horizontal < 0)
        {
            right = false;
            velocHorizontal = -1;
        }
        Vector3 movement = new Vector3(velocHorizontal, 0, 0);
        // Mover al personaje
        if (movement.magnitude > 0.1f)
        {
            
            // Rotaci�n hacia la direcci�n del movimiento
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

        // Salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        // Aplicar gravedad
        velocity.y += gravity * Time.deltaTime;

        // Mover al jugador seg�n la velocidad vertical
        characterController.Move(velocity * Time.deltaTime);

        // Configurar el par�metro de velocidad para animaciones
        animator.SetFloat("Speed", movement.magnitude);
    }

    private void FixedUpdate()
    {
        if (!isGrounded) { animator.SetBool("jump", true); }
        else { animator.SetBool("jump", false); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if ((collision.gameObject.CompareTag("EnemyBullet") && !playerShoot.IsParrying()) || (collision.gameObject.CompareTag("Enemy")))
        {
            Debug.Log("Lost hp by " + collision.gameObject.tag);
            Debug.Log(gameManager.GetHealth());
            gameManager.SetHealth(1, null);
            IsDead();
        }
        
    }

    /*private IEnumerator Invurnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 3, true);

        for (int i = 0; i < flashNumbers; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(1);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(1);
        }

        Physics2D.IgnoreLayerCollision(6, 3, false);

    }*/

    private void IsDead()
    {
        if (gameManager.GetHealth() <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Muerto");
        }
    }


}
