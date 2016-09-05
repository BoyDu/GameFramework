using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//状态转移的条件
public enum Transition
{
    Idle,
    SawEnemy,   //发现敌人
    ReachEnemy, //接近敌人
    LostEnemy,  //敌人离开视野
    NoHP,       //死亡
}

//状态id
public enum StateID
{
    Idle,   //站立
    Move,   //此状态不由状态机控制
    Patrol, //巡逻
    Chase,  //追逐
    Attack, //进攻
    Dead,   //死亡
}

public abstract class FSMState
{
    //保存此状态转移到下一状态的条件  this : 此状态    Key : 条件   Value ：下一状态
    protected Dictionary<Transition, FSMState> m_dicTrans = new Dictionary<Transition, FSMState>();

    public void AddTransition(Transition trans, FSMState st)
    {
       
        if(m_dicTrans.ContainsKey(trans))
        {
            Debug.LogError("已经包含转移条件");
            return;
        }
        m_dicTrans.Add(trans, st);
    }

    public void DeleteTransition(Transition trans)
    {

        if(m_dicTrans.ContainsKey(trans))
        {
            m_dicTrans.Remove(trans);
        }
    }

    public FSMState GetState(Transition trans)
    {
        FSMState st = null;
        m_dicTrans.TryGetValue(trans, out st);
        return st;
    }
    public virtual void Reason(Entity entity) { }
    public virtual void Enter(Entity entity) { }
    public virtual void Excute(Entity entity) { }
    public virtual void Exit(Entity entity) { }
}

public class FSMStateMachine
{
    private Dictionary<StateID, FSMState> m_dicStates;
    private FSMState m_curState;
    public FSMState CurState { get { return m_curState; } }
    private Entity m_owner;
    public FSMStateMachine(Entity entity)
    {
        m_dicStates = new Dictionary<StateID, FSMState>();
        m_owner = entity;
    }
    public void AddState(StateID id,FSMState st)
    {
        if(st == null)
        {
            Debug.LogError("不能添加空状态");
            return;
        }
        if (m_dicStates.ContainsKey(id))
            m_dicStates[id] = st;
        else
            m_dicStates.Add(id, st);
    }

    public void DeleteState(StateID id)
    {
        m_dicStates.Remove(id);
    }

    //用来初始化状态
    public void Start(FSMState st)
    {
        m_curState = st;
        m_curState.Enter(m_owner);
    }

    public void PerformTransition(Transition trans)
    {
       
        FSMState state = m_curState.GetState(trans);
        if(state != null)
        {
            Debug.Log("切换到状态 ： " + trans.ToString());
            m_curState.Exit(m_owner);
            m_curState = state;
            m_curState.Enter(m_owner);
        }
        else
        {
            Debug.LogError("转换到 " + trans.ToString() + " 失败");
        }
    }

    public void Update()
    {
        if (m_curState != null)
        {
            m_curState.Reason(m_owner);
            m_curState.Excute(m_owner);
        }
    }
}

//AI数据的集合  类似行为树的blackboard
public class Blackboard
{
    public Entity target;
    public Vector3 bornPos;     //出生位置
    public float chaseDist;     //追击距离
    public Vector3 des;
}