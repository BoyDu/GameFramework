using UnityEngine;
using System.Collections;

public class ChaseState : FSMState 
{
    Vector3 des;
    public override void Enter(Entity entity)
    {
        des = entity.blackboard.target.Pos;
        entity.Move.MoveTo(des);
    }
    public override void Reason(Entity entity)
    {
        des = entity.blackboard.target.Pos;
        float dist = (entity.Pos - des).sqrMagnitude;
        if(dist <= entity.Skill.AttackDistance * entity.Skill.AttackDistance)
        {
            Debug.Log("切换到 AttackState");
            entity.AI.SetTransition(Transition.ReachEnemy);
        }
        else if (dist > entity.blackboard.chaseDist * entity.blackboard.chaseDist)
        {
            Debug.Log("切换到 PatrolState");
            entity.AI.SetTransition(Transition.LostEnemy);
        }
    }

    public override void Excute(Entity entity)
    {
        if(!des.Equals(entity.blackboard.target.Pos))
        {
            des = entity.blackboard.target.Pos;
            entity.Move.MoveTo(des);
            entity.Anim.SyncAction("Run");
        }
    }
}
