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
}
