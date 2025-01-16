using UnityEngine;

public class State : IState
{

    protected BossController boss;

    public State(BossController boss)
    {
        this.boss = boss;
    }

    public virtual void Entry()
    {

    }

    public virtual void Exit()
    {

    }
    
    public virtual void Update()
    {

    }

}
