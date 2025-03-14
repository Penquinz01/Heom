using UnityEngine;

public class EnemyStateMAchine
{
    public IEnemyStates currentState { get; private set; }
    public Enemy enemy;
    public Idle idle { get; private set; }
    public Chase chase { get; private set; }
    public Attack attack { get; private set; }

    public EnemyStateMAchine(Enemy enemy)
    {
        this.enemy = enemy;
        idle = new Idle(enemy, this);
        chase = new Chase(enemy, this);
        attack = new Attack(enemy, this);
        Transition(idle);
    }
    public void StateUpdate()
    {
        currentState.Update();
    }
    public void StateFixedUpdate()
    {
        currentState.FixedUpdate();
    }   
    public void Transition(IEnemyStates State) {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = State;
        currentState.Enter();
    }
}
