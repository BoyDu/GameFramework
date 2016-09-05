using UnityEngine;
using System.Collections;

public class AIModule : ModuleBase
{
    FSMStateMachine m_stateMachine;
    public AIModule(Entity entity)
        : base(entity)
    {
        m_stateMachine = new FSMStateMachine(entity);
        InitBlackboard();
        MakeFSM();
    }

    void MakeFSM()
    {
        PatrolState patrol = new PatrolState();
        ChaseState chase = new ChaseState();
        AttackState attack = new AttackState();
        DeadState dead = new DeadState();
        IdleState idle = new IdleState();
        MoveState move = new MoveState();

        patrol.AddTransition(Transition.SawEnemy, chase);
        patrol.AddTransition(Transition.NoHP, dead);

        chase.AddTransition(Transition.LostEnemy, patrol);
        chase.AddTransition(Transition.ReachEnemy, attack);
        chase.AddTransition(Transition.NoHP, dead);

        attack.AddTransition(Transition.LostEnemy, patrol);
        attack.AddTransition(Transition.SawEnemy, chase);
        attack.AddTransition(Transition.NoHP, dead);

        AddState(StateID.Patrol, patrol);
        AddState(StateID.Chase, chase);
        AddState(StateID.Attack, attack);
        AddState(StateID.Dead, dead);



        m_stateMachine.Start(patrol);

    }

    void InitBlackboard()
    {
        m_entity.blackboard.bornPos = m_entity.Pos;
        m_entity.blackboard.chaseDist = 16f;     
    }

    float lastTime = 0;
    public override void Update()
    {
//         if (!m_entity.UseAI)
//             return;

        if (Time.time - lastTime <= 0.2f)
            return;

        lastTime = Time.time;
        m_stateMachine.Update();
        
    }

    public void AddState(StateID id,FSMState st)
    {
        m_stateMachine.AddState(id, st);
    }

    public void SetTransition(Transition trans)
    {
        m_stateMachine.PerformTransition(trans);
    }

    public override void OnEvent(eEntityEvent eventID, object args = null)
    {
        if (eventID == eEntityEvent.OnAlive)
        {

        }
        else if (eventID == eEntityEvent.OnDead)
        {

        }
    }
}
