using System.Collections;
using UnityEngine;

public class StareState : State
{
    public StareState(BossController boss) : base(boss) { }

    public override void Entry()
    {
        base.Entry();
        boss.StartCoroutine(Spit());
        Debug.Log("Follow State Entered");
    }

    public override void Update()
    {
        base.Update();
        //if (Boss.GetHealthPercentage() < .5f) Boss.ChangeStateKey(States.Rage);
    }

    IEnumerator Spit()
    {
        yield return new WaitForSeconds(5f);

        boss.ChangeStateKey(States.Spit);
    }
}
