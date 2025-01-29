using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpitState : State
{
    public SpitState(BossController boss) : base(boss) { }

    private GameObject spit;
    private Vector3 spitPos;
    private Quaternion spitRotation;
    private Octopus actualBoss;
    private GameObject spitInstance;
    private float timer = 0f;
    private float duration = 3f;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        spit = actualBoss.GetSpit();
        spitPos = boss.transform.position + (new Vector3(0, 2.5f, 0)); //Posici�n donde se instancia el prefab
        spitRotation = boss.transform.rotation;
        Debug.Log("Spit State Entered");

        // Instancia la tinta
        Debug.Log(spitPos + " , " + spitRotation);
        spitInstance = UnityEngine.Object.Instantiate(spit, spitPos, Quaternion.identity);
        Debug.Log("Spit instantiated successfully: " + spitInstance.name);
        timer = 0f; // Reinicia el contador
    }

    public override void Update()
    {
        timer += Time.deltaTime;

        if (timer >= duration)
        {
            Debug.Log("Spit State completed. Changing state...");
            Exit();
            States randomState = GetRandomEnumValue<States>(States.Spit);
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
