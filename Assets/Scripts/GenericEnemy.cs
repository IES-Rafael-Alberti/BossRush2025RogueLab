using System.Collections;
using UnityEngine;

public class GenericEnemy : MonoBehaviour
{
    // Color al que se cambiará el cubo cuando sea tocado por la bala
    private Renderer cuboRenderer;

    void Start()
    {
        // Obtener el Renderer del cubo
        cuboRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Bala"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(cuboRenderer);
            // Cambiar el color del cubo al colorImpacto
            if (cuboRenderer != null)
            {
                cuboRenderer.material.color = Color.red; //Color impacto
                FrameI();
                cuboRenderer.material.color = Color.white; //Color original
            }
        }
    }

    IEnumerator FrameI()
    {
        yield return 1f;
    }
}
