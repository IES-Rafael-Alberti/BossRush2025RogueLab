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
        States randomState = GetRandomEnumValue<States>(States.Spit);
        actualBoss.ChangeStateKey(randomState);
    }
}
