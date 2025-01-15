using UnityEngine;

public class State : IState
{

    protected MonoBehaviour boss;

    public State(MonoBehaviour boss)
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
