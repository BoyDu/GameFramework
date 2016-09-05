using System;
using System.Collections.Generic;
using UnityEngine;
public class PatrolState : FSMState
{
    Vector3 des;

    public override void Enter(Entity entity)
    {
        des = GetRandomPos(entity);
        entity.Move.MoveTo(des);
    }
    public override void Reason(Entity entity)
    {
        Entity enemy = SkillProcesser.GetTargetInDistance(entity, entity.blackboard.chaseDist);
        if(enemy != null)
        {
            Debug.Log("切换到 ChaseState");
            entity.blackboard.target = enemy;
            entity.AI.SetTransition(Transition.SawEnemy);
        }
    }

    public override void Excute(Entity entity)
    {
        if((entity.Pos - des).sqrMagnitude <= 0.5f)
        {
            des = GetRandomPos(entity);
            entity.Move.MoveTo(des);
        }
    }

    Vector3 GetRandomPos(Entity entity)
    {
        float x = UnityEngine.Random.Range(0, 1);
        float z = UnityEngine.Random.Range(0, 1);
        Vector3 dir = new Vector3(x, 0, z);
        return entity.blackboard.bornPos + dir.normalized * 5f;
    }
}
