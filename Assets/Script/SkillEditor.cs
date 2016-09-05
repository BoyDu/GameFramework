﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Reflection;
public class SkillEditor : MonoBehaviour
{

    InputField HeroConfig;     
    InputField SkillID;         
    InputField SkillType;     
    InputField AttackType;
    InputField AttackDistance;
    InputField HitTime;
    InputField FlySpeed;
    InputField CastEffect;
    InputField CastEffectBeginTime;
    InputField CastEffectDuration;
    InputField CastEffectBindBone;
    InputField BulletEffect;
    InputField BulletEffectBeginTime;
    InputField BulletEffectBindBone;
    InputField BeAttackEffect;
    InputField CastAction;
    InputField CastActionBeginTime;
    InputField BeAttackAction;


    public static Entity MainPlayer = null;
    uint HeroConfigID;
    uint m_curSkillID;
    CSVSkill m_SkillInfo = null;

    static string[] ItemName = new string[]
    {
        "HeroConfig","SkillID","SkillType","AttackType","AttackDistance","HitTime",
        "FlySpeed","CastEffect","CastEffectBeginTime","CastEffectDuration","CastEffectBindBone",
        "BulletEffect","BulletEffectBeginTime","BulletEffectBindBone","BeAttackEffect","CastAction",
        "CastActionBeginTime","BeAttackAction"
    };

    void FindGameObjects()
    {
        Type type = this.GetType();
        for(int i = 0;i < ItemName.Length;i++)
        {
            InputField tmp = transform.FindChild(ItemName[i] + "/InputField").GetComponent<InputField>();
            //通过反射 给那几个InputField成员变量赋值
            FieldInfo pi = type.GetField(ItemName[i],BindingFlags.NonPublic | BindingFlags.Instance);
            pi.SetValue(this, tmp);
        }
    }

    void BindEvent()
    {
        UnityEngine.Events.UnityAction[] actions = new UnityEngine.Events.UnityAction[]
        {
            LoadHero,
            LoadSkillConfig,
            ()=>{m_SkillInfo.type = Convert.ToUInt32( SkillType.text); },
            ()=>{m_SkillInfo.attackType = Convert.ToUInt32(AttackType.text);},
            ()=>{m_SkillInfo.attackDistance = Convert.ToUInt32(AttackDistance.text);},
            ()=>{m_SkillInfo.hitTime = Convert.ToSingle(HitTime.text);},
            ()=>{m_SkillInfo.flySpeed = Convert.ToSingle(FlySpeed.text);},
            ()=>{m_SkillInfo.castEffect = CastEffect.text;},
            ()=>{m_SkillInfo.castEffectBeginTime = Convert.ToSingle(CastEffectBeginTime.text);},
            ()=>{m_SkillInfo.castEffectDuration = Convert.ToSingle(CastEffectDuration.text);},
            ()=>{m_SkillInfo.castEffectBindBone = CastEffectBindBone.text;},
            ()=>{m_SkillInfo.BulletEffect = BulletEffect.text;},
            ()=>{m_SkillInfo.BulletBeginTime = Convert.ToSingle(BulletEffectBeginTime.text);},
            ()=>{m_SkillInfo.BulletBindBone = BulletEffectBindBone.text;},
            ()=>{m_SkillInfo.beattackEffect = BeAttackEffect.text;},
            ()=>{m_SkillInfo.castAction = CastAction.text;},
            ()=>{m_SkillInfo.castActionBeginTime = Convert.ToSingle(CastActionBeginTime.text);},
            ()=>{m_SkillInfo.beattackAction = BeAttackAction.text;}
        };

        for(int i = 0; i < ItemName.Length;i++)
        {
            transform.FindChild(ItemName[i] + "/Button").GetComponent<Button>().onClick.AddListener(actions[i]);
        }

        transform.FindChild("CurSkill").GetComponent<Button>().onClick.AddListener(
            ()=>
            {                
                if(m_SkillInfo == null)
                {
                    Debug.LogError("还没加载技能呢 ！！！");
                    return;
                }
                //每次都new新的技能，以确保技能配置是修改过后的
                MainPlayer.Skill.CastSkill(new SkillBase(m_SkillInfo,MainPlayer));
            }
            );

    }

    void LoadHero()
    {
        HeroConfigID = Convert.ToUInt32(HeroConfig.text);
        MainPlayer = EntityManager.Instance.Get(HeroConfigID, 1,eCamp.Hero);
        if(MainPlayer == null)
        {
            Debug.LogError("加载英雄失败！ configID = " + HeroConfigID);
            return;
        }

        MainPlayer.Pos = new Vector3(28.5f, 4.6f, 45f);
        CameraController.Instance.LookTarget = MainPlayer;
        GameManager.MainPlayer = MainPlayer;

        LoadEnemy();
    }

    void LoadEnemy()
    {
        Entity enemy = EntityManager.Instance.Get(HeroConfigID, 2,eCamp.Enemy);
        enemy.Pos = new Vector3(25f, 4.6f, 42f);
    }

    void LoadSkillConfig()
    {
        m_curSkillID = Convert.ToUInt32(SkillID.text);
        m_SkillInfo = CSVManager.GetSkillCfg(m_curSkillID);
        if (m_SkillInfo == null)
        {
            Debug.LogError("不存在技能id " + m_curSkillID);
            return;
        }

        SkillType.text = m_SkillInfo.type.ToString();   
        AttackType.text = m_SkillInfo.attackType.ToString(); 
        //MagicType.text = m_SkillInfo.magicType.ToString(); 
        AttackDistance.text = m_SkillInfo.attackDistance.ToString(); 
        HitTime.text = m_SkillInfo.hitTime.ToString(); 
        FlySpeed.text = m_SkillInfo.flySpeed.ToString();
        CastEffect.text = m_SkillInfo.castEffect == null ? "" : m_SkillInfo.castEffect; 
        CastEffectBeginTime.text = m_SkillInfo.castEffectBeginTime.ToString(); 
        CastEffectDuration.text = m_SkillInfo.castEffectDuration.ToString();
        CastEffectBindBone.text = m_SkillInfo.castEffectBindBone == null ? "" : m_SkillInfo.castEffectBindBone;
        BulletEffect.text = m_SkillInfo.BulletEffect == null ? "" : m_SkillInfo.BulletEffect; 
        BulletEffectBeginTime.text = m_SkillInfo.BulletBeginTime.ToString();
        BulletEffectBindBone.text = m_SkillInfo.BulletBindBone == null ? "" : m_SkillInfo.BulletBindBone;
        BeAttackEffect.text = m_SkillInfo.beattackEffect == null ? "" : m_SkillInfo.beattackEffect;
        CastAction.text = m_SkillInfo.castAction == null ? "" : m_SkillInfo.castAction; 
        CastActionBeginTime.text = m_SkillInfo.castActionBeginTime.ToString();
        BeAttackAction.text = m_SkillInfo.beattackAction == null ? "" : m_SkillInfo.beattackAction;
    }


    void Start()
    {
        GameDefine.UseBundle = false;
        GameDefine.UseAstar = false;
        FindGameObjects();
        BindEvent();
        CSVManager.LoadAllCsv();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        EntityManager.Instance.Update();
        EffectManager.Instance.Update();
        BulletManager.Instance.Update();

    }

    void OnApplicationQuit()
    {
        CSVManager.ClearAllCsv();
        EntityManager.Instance.Clear();
        EffectManager.Instance.Clear();
        BulletManager.Instance.Clear();
        Log.Info("application quit.");
        Log.Stop();
    }

    void ReloadAllConfig()
    {
        CSVManager.ClearAllCsv();
        EntityManager.Instance.Clear();
        EffectManager.Instance.Clear();
        BulletManager.Instance.Clear();

        CSVManager.LoadAllCsv();
    }

}
