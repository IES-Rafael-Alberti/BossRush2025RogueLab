using System.Collections;
using UnityEngine;

public class StareState : State
{
    public StareState(BossController boss) : base(boss) { }

    private Octopus actualBoss;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        actualBoss.StartCoroutine(Spit());
        Debug.Log("Follow State Entered");
    }

    public override void Update()
    {
        base.Update();
        //if (Boss.GetHealthPercentage() < .5f) Boss.ChangeStateKey(States.Rage);
    }

    IEnumerator Spit()
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("Try spit");
        actualBoss.ChangeStateKey(States.Spit);
    }
}
