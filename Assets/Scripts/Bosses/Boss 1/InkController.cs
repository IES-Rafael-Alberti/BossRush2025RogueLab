using System.Collections;
using UnityEngine;

public class InkController : MonoBehaviour
{

    //Esta clase es un script que controla el movimiento de la tinta del pulpo al instanciar su prefab
    private GameObject player;
    private Rigidbody rb;
    private SphereCollider colliderInk;
    [SerializeField] private float force;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        colliderInk = GetComponent<SphereCollider>();

        Vector3 direction = (player.transform.position - transform.position).normalized;

        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision against: " + collision.gameObject.name);
        
    }

}
