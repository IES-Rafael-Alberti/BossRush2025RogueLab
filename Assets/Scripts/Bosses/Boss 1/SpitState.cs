using UnityEngine;

public class SpitState : State
{
    public SpitState(BossController boss) : base(boss) { }

    private GameObject spit;
    private Vector3 spitPos;
    private Octopus actualBoss;

    public override void Entry()
    {
        base.Entry();
        actualBoss = (Octopus)boss;
        spit = actualBoss.GetSpit();
        spitPos = boss.transform.position + (new Vector3(0, 2.5f, 0)); //Posici�n donde se instancia el prefab
        Debug.Log("Spit State Entered");

        // Instancia la tinta
        Object.Instantiate(spit, spitPos, Quaternion.identity);
        // Siguiente estado
        actualBoss.ChangeStateKey(States.Stare);
    }
}
