using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public AttackState(BossController boss) : base(boss) { }

    private Octopus actualBoss;
    private Animator anim;
    private string Attack = "Attack1";
    private float timer = 0f;
    private float duration = 2f;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        Debug.Log("Attack State Entered");
        anim = actualBoss.GetComponent<Animator>();
        // Animación
        anim.SetTrigger(Attack);
        timer = 0f; // Reinicia el contador
    }

    public override void Update()
    {

        timer += Time.deltaTime;

        // Verificar si la animación  ha terminado
        Debug.Log("Animación");
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f && !anim.IsInTransition(0) && timer >= duration)
        {
            Debug.Log("Animación acabada.");
            anim.ResetTrigger("Attack1");
            // Cambio de estado
            Exit();
            States randomState = GetRandomEnumValue<States>(States.Attack);
            actualBoss.ChangeStateKey(randomState);
        }
    }

    T GetRandomEnumValue<T>(T exclude) where T : Enum
    {
        Array values = Enum.GetValues(typeof(T)); // Obtiene todos los valores del enum

        // Filtrar los valores para excluir el estado actual
        List<T> filteredValues = new List<T>();
        foreach (T value in values)
        {
            if (!value.Equals(exclude))
            {
                filteredValues.Add(value);
            }
        }

        // Generar un índice aleatorio en la lista filtrada
        int randomIndex = UnityEngine.Random.Range(0, filteredValues.Count);
        return filteredValues[randomIndex]; // Retorna un valor aleatorio excluyendo el estado actual
    }
}
