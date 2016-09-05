using UnityEngine;
using System.Collections;

public class AttackState : FSMState {

    public override void Reason(Entity entity)
    {
        float dist = (entity.Pos - entity.blackboard.target.Pos).sqrMagnitude;
        if(dist > Mathf.Pow(entity.Skill.AttackDistance,2) && dist <= Mathf.Pow(entity.blackboard.chaseDist,2))
        {
            Debug.Log("切换到 ChaseState");
            entity.AI.SetTransition(Transition.SawEnemy);
        }
        else if(dist > Mathf.Pow(entity.blackboard.chaseDist,2))
        {
            Debug.Log("切换到 PatrolState");
            entity.AI.SetTransition(Transition.LostEnemy);
        }
    }

    int skillIndex = 0;
    public override void Excute(Entity entity)
    {
        entity.SelectTarget = entity.blackboard.target;
        if(entity.SelectTarget == null || entity.SelectTarget.IsDead)
        {
            Debug.Log("切换到 PatrolState");
            entity.AI.SetTransition(Transition.LostEnemy);
        }
        entity.Skill.CastSkill(skillIndex++);
        if (skillIndex > 3)
            skillIndex = 0;
    }
}
