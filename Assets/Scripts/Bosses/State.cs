using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class State : IState
{
    // Interfaz de la m�quina de estado de los bosses
    protected BossController boss;

    public State(BossController boss)
    {
        this.boss = boss;
    }

    public virtual void Entry()
    {

    }


    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void PlayAudio(AudioSource audioSource)
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }

    public virtual T GetRandomEnumValue<T>(T exclude) where T : Enum
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
