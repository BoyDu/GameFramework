using UnityEngine;
using System.Collections;

public class BuffHitFly : BuffBase
{
    float speed = 2f;
    float YOffset = 0f;
    float t = 0f;
    float startY = 0f;
    public BuffHitFly(int buffID,Entity buffOwner,Entity caster) : base(buffID,buffOwner,caster)
    {

    }
    public override void BuffStart()
    {
        base.BuffStart();
        startY = YOffset = buffOwner.Pos.y;
        t = 0f;
    }

    public override void BuffUpdate()
    {
        base.BuffUpdate();
        t += Time.deltaTime;
        YOffset = speed * t - 0.5f * 9.8f * t * t;
        if (YOffset < startY)
            YOffset = startY;
        buffOwner.Pos = new Vector3(buffOwner.Pos.x, buffOwner.Pos.y + YOffset, buffOwner.Pos.z);
    }

    public override void BuffEnd()
    {
        base.BuffEnd();
        buffOwner.Pos = new Vector3(buffOwner.Pos.x, startY, buffOwner.Pos.z);
    }
}
