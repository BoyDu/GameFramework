using UnityEngine;
using System.Collections.Generic;

public class BuffManager
{
    static Dictionary<int, HashSet<BuffBase>> m_dicBuffPool = new Dictionary<int, HashSet<BuffBase>>();
    //buff工厂，根据buff配置信息来决定具体创建哪种buff
	public static BuffBase CreateBuff(int buffID,Entity owner,Entity caster)
    {
        BuffBase buff = null;
        switch (buffID)
        {
            case 1:
                {
                    buff = new BuffHitFly(buffID, owner,caster);
                }
                break;
            default:
                break;
        }

        return buff;
    }

    public static BuffBase GetBuff(int buffID,Entity owner,Entity caster)
    {
        HashSet<BuffBase> hash = null;
        if(!m_dicBuffPool.TryGetValue(buffID,out hash))
        {
            hash = new HashSet<BuffBase>();
            m_dicBuffPool.Add(buffID, hash);
        }

        BuffBase buff = null;
        var e = hash.GetEnumerator();
        if(e.MoveNext())
        {
            buff = e.Current;
            hash.Remove(buff);
            buff.Reset(buffID, owner, caster);
        }
        else
        {
            buff = CreateBuff(buffID,owner,caster);
        }
        return buff;
    }

    public static void PushToPool(BuffBase buff)
    {
        HashSet<BuffBase> hash = null;
        if(!m_dicBuffPool.TryGetValue(buff.buffInfo.ID,out hash))
        {
            hash = new HashSet<BuffBase>();
            m_dicBuffPool.Add(buff.buffInfo.ID, hash);
        }

        if(!hash.Contains(buff))
        {
            hash.Add(buff);
        }
    }

    public static void Clear()
    {
        m_dicBuffPool.Clear();
    }
}
