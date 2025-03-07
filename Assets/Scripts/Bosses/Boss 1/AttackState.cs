using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AttackState : State
{
    public AttackState(BossController boss) : base(boss) { }

    private Octopus actualBoss;
    private Animator anim;
    private string Attack = "Attack1";
    private float timer = 0f;
    private float duration = 2f;
    private AudioSource audioSource;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        Debug.Log("Attack State Entered");
        anim = actualBoss.GetComponent<Animator>();
        audioSource = actualBoss.GetAttackSound();
        // Animación
        anim.SetTrigger(Attack);
        PlayAudio(audioSource);
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
            anim.ResetTrigger("Attack1");
            // Cambio de estado
            Exit();
            actualBoss.ChangeStateKey(States.Stare);
        }
    }

}
