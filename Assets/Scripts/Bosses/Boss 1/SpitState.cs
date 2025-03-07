using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;


public class SpitState : State
{
    public SpitState(BossController boss) : base(boss) { }

    private GameObject spit;
    private Vector3 spitPos;
    private Quaternion spitRotation;
    private Octopus actualBoss;
    private GameObject spitInstance;
    private float timer = 0f;
    private float duration = 2f;
    private AudioSource audioSource;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        spit = actualBoss.GetSpit();
        spitPos = boss.transform.position + (new Vector3(0, 2.5f, 0)); //Posici�n donde se instancia el prefab
        spitRotation = boss.transform.rotation;
        Debug.Log("Spit State Entered");
        audioSource = actualBoss.GetSweepSound();
        // Instancia la tinta
        Debug.Log(spitPos + " , " + spitRotation);
        spitInstance = UnityEngine.Object.Instantiate(spit, spitPos, Quaternion.identity);
        PlayAudio(audioSource);
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
            actualBoss.ChangeStateKey(States.Stare);
        }
    }
}
