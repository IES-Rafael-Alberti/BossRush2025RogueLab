using UnityEngine;

public class SpitState : State
{
    public SpitState(BossController boss) : base(boss) { }

    private GameObject spit;
    private Vector2 spitPos;
    private Octopus actualBoss;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        spit = actualBoss.GetSpit();
        spitPos = (Vector2)boss.transform.position + (new Vector2(0, 0.7f));
        Debug.Log("Spit State Entered");

        // instanciar proyectil
        Object.Instantiate(spit, spitPos, Quaternion.identity);
        // siguiente estado
        //Boss.ChangeStateKey(States.Recovery);
    }
}
