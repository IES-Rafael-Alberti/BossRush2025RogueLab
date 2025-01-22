using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    //Clase genérica para todos los bosses

    private float currentHealth; //Vida actual
    [SerializeField] private float maxHealth = 10; //Vida máxima

    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();
    void Start()
    {
        // Inicializar datos boss
        currentHealth = maxHealth;
        
        // Inicializar estados:
        // Definir estado inicial
        currentState = new StareState(this);
        currentState.Entry();
        // Crear lista de estados
        //statesDict.Add(States.Spit, new SpitState(this));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeStateKey(States newState)
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

}
