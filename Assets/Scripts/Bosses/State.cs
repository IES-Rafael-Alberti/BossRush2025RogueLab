using UnityEngine;

public class State : IState
{
    // Interfaz de la máquina de estado de los bosses
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
