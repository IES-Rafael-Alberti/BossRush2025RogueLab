using UnityEngine;

public class enemie : MonoBehaviour
{
    // Color al que se cambiará el cubo cuando sea tocado por la bala
    public Color colorImpacto = Color.red;

    private Renderer cuboRenderer;

    void Start()
    {
        // Obtener el Renderer del cubo
        cuboRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Bala"
        if (collision.gameObject.CompareTag("Bala"))
        {
            Debug.Log(cuboRenderer);
            // Cambiar el color del cubo al colorImpacto
            if (cuboRenderer != null)
            {
                cuboRenderer.material.color = colorImpacto;
            }
        }
    }
}
