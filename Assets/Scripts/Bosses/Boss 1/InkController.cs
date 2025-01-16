using System.Collections;
using UnityEngine;

public class InkController : MonoBehaviour
{
    private GameObject player;
    private Rigidbody rb;
    private SphereCollider colliderInk;
    [SerializeField] private float force;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        colliderInk = GetComponent<SphereCollider>();

        Vector3 direction = (Vector3)player.transform.position - (Vector3)transform.position;
        rb.AddForce(direction, ForceMode.Impulse);
    }

    void Update()
    {

        if (colliderInk.isTrigger == false) { BecomeTrigger(); }        
    }

    IEnumerator BecomeTrigger()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Become trigger entered");
        colliderInk.isTrigger = true;
    }

}
