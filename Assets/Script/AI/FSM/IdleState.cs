using UnityEngine;
using System.Collections;

public class IdleState : FSMState
{

    public override void Enter(Entity entity)
    {
        entity.Anim.SyncAction("Idle_Sword");
    }

    //     public override void Excute(Entity entity)
    //     {
    //         //entity.Anim.SyncAction("Idle_Sword");
    //     }
    // 
    //     public override void Exit(Entity entity)
    //     {
    //         
    //    }
}
