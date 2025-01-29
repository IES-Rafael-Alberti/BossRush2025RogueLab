using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareState : State
{
    public StareState(BossController boss) : base(boss) { }

    private Octopus actualBoss;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        Debug.Log("Follow State Entered");
        States randomState = GetRandomEnumValue<States>(States.Stare);
        actualBoss.ChangeStateKey(randomState);
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
