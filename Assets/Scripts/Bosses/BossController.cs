using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    //Clase gen�rica para todos los bosses

    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();
    void Start()
    {
        // Inicializar datos boss
        
        // Inicializar estados:
        // Definir estado inicial
        currentState = new StareState(this);
        currentState.Entry();
        // Crear lista de estados
        //statesDict.Add(States.Spit, new SpitState(this));
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
