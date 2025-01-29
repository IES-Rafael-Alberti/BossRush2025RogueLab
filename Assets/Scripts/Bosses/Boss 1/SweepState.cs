using System;
using System.Collections.Generic;
using UnityEngine;

public class SweepState : State
{
    public SweepState(BossController boss) : base(boss) { }

    private Octopus actualBoss;
    private Animator anim;
    private string Sweep;
    private float timer = 0f;
    private float duration = 2f;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        Debug.Log("Sweep State Entered");
        anim = actualBoss.GetComponent<Animator>();
        // Animación
        int num = UnityEngine.Random.Range(1, 3);
        Sweep = num == 1 ? "Sweep1" : "Sweep2";
        anim.SetTrigger(Sweep);
        timer = 0f; // Reinicia el contador
    }

    public override void Update()
    {

        timer += Time.deltaTime;

        // Verificar si la animación  ha terminado
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f && !anim.IsInTransition(0) && timer >= duration)
        {
            Debug.Log("Animación acabada.");
            anim.ResetTrigger("Sweep1");
            anim.ResetTrigger("Sweep2");
            // Cambio de estado
            Exit();
            States randomState = GetRandomEnumValue<States>(States.Sweep);
            actualBoss.ChangeStateKey(randomState);
        }
    }
}
