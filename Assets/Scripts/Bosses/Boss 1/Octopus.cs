using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Octopus : BossController
{

    [SerializeField] private GameObject spit;
    private float currentHealth; //Vida actual
    [SerializeField] private float maxHealth = 10; //Vida m�xima
    private Renderer BossRenderer;
    

    State currentState;
    Dictionary<States, State> statesDict = new Dictionary<States, State>();

    void Start()
    {
        BossRenderer = GetComponent<Renderer>();
        currentHealth = maxHealth;
        currentState = new StareState(this);
        //      Crear lista de estados
        Debug.Log("Initial Octopus");
        statesDict.Add(States.Stare, currentState); //Estado mirar
        statesDict.Add(States.Attack, new AttackState(this)); //Estado atacar
        statesDict.Add(States.Spit, new SpitState(this)); //Estado escupir
        statesDict.Add(States.Sweep, new SweepState(this)); //Estado barrer
        currentState.Entry();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
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
            Debug.Log(currentHealth);
            currentHealth--;
            // Cambiar el color del cubo al colorImpacto
            if (BossRenderer != null)
            {
                BossRenderer.material.color = Color.red; //Color impacto
            }
            IsDead();
        }

        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

    private void IsDead()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Muerto");
        }
    }

}

public enum States
{
    Stare, Spit, Attack, Sweep
}
