using UnityEngine;
using System.Collections;

public class MoveState : FSMState
{

//     public override void Enter(Entity entity)
//     {
//         entity.Move.m_navAgent.updateRotation = true;
//         entity.Move.m_navAgent.speed = entity.Property.MoveSpeed;
//        // entity.Move.m_navAgent.SetDestination(entity.blackboard.des);
//         entity.Anim.SyncAction("Run");
//          entity.Move.m_navAgent.destination = entity.blackboard.des;
//          entity.Move.m_navAgent.Resume();
//     }
// 
//     public override void Reason(Entity entity)
//     {
//         if (entity.Move.m_navAgent.remainingDistance < 0.01f)
//             entity.AI.SetTransition(Transition.Idle);
//     }
// 
//     public override void Exit(Entity entity)
//     {
//         entity.Move.m_navAgent.Stop();
//     }
}
