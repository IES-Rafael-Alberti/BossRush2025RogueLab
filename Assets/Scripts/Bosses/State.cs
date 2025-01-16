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
        throw new System.NotImplementedException();
    }

    public virtual void Exit()
    {
        throw new System.NotImplementedException();
    }
    
    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }

}
