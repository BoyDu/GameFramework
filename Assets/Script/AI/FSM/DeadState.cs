using UnityEngine;
using System.Collections;

public class DeadState : FSMState {

    public override void Enter(Entity entity)
    {
        entity.Anim.SyncAction("Die");
    }
}
