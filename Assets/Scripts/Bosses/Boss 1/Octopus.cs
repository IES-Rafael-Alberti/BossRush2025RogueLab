using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Octopus : BossController
{

    [SerializeField] private GameObject spit;

    public float currentHealth;
    private float maxHealth = 200;

    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();
    void Start()
    {
        // inicializar datos boss
        currentHealth = maxHealth;

        // inicializar estados:
        //      definir estado inicial
        currentState = new StareState(this);
        currentState.Entry();
        //      crear lista de estados
        statesDict.Add(States.Stare, currentState);
        statesDict.Add(States.Spit, new SpitState(this));
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

    public GameObject GetSpit()
    {
        return spit;
    }
}

public enum States
{
    Stare, Spit, Sweep
}
