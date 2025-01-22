using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Octopus : BossController
{

    [SerializeField] private GameObject spit;
    private Renderer BossRenderer;

    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();

    void Start()
    {
        BossRenderer = GetComponent<Renderer>();

        currentState = new StareState(this);
        currentState.Entry();
        //      Crear lista de estados
        Debug.Log("Initial Octopus");
        statesDict.Add(States.Stare, currentState); //Estado mirar
        statesDict.Add(States.Spit, new SpitState(this)); //Estado escupir
    }

    public new void ChangeStateKey(States newState)
    {
        if (statesDict.ContainsKey(newState))
        {
            ChangeState(statesDict[newState]);
        }
        else
        {
            Debug.LogWarning("State not in list.");
        }
    }

    void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Entry();
    }

    public GameObject GetSpit()
    {
        return spit;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona tiene el tag "Bala"
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log(BossRenderer);
            // Cambiar el color del cubo al colorImpacto
            if (BossRenderer != null)
            {
                BossRenderer.material.color = Color.red; //Color impacto
            }
        }
    }

}

public enum States
{
    Stare, Spit, Sweep
}
