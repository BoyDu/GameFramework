using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class FightPanel : MonoBehaviour {

    Button _ChangeWeaponBtn = null;
    Button _LoadEnemy = null;
    Button _LoadFriend = null;
    Button _ChangeScene = null;
	// Use this for initialization
    void Awake()
    {
        _ChangeWeaponBtn = transform.FindChild("ChangeWeaponBtn").GetComponent<Button>();
        if (_ChangeWeaponBtn != null)
            _ChangeWeaponBtn.onClick.AddListener(ChangeWeapon);
        _LoadEnemy = transform.FindChild("LoadEnemy").GetComponent<Button>();
        if (_LoadEnemy != null)
            _LoadEnemy.onClick.AddListener(LoadEnemy);
        _ChangeScene = transform.FindChild("ChangeScene").GetComponent<Button>();
        if (_ChangeScene != null)
            _ChangeScene.onClick.AddListener(ChangeScene);
        _LoadFriend = transform.FindChild("LoadFriend").GetComponent<Button>();
        if (_LoadFriend != null)
            _LoadFriend.onClick.AddListener(LoadFriend);
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ChangeWeapon()
    {
        var e = EntityManager.Instance.m_dicObject.GetEnumerator();
        while(e.MoveNext())
        {
            if (e.Current.Value.IsDead)
                continue;
            e.Current.Value.Render.RandomChangeWeapon();
        }
    }

    uint EntityID = 10;

    uint[] configs = new uint[] { 10, 11, 20, 21 };
    void LoadEnemy()
    {
        uint configID = configs[Random.Range(0, 3)];

        Entity enemy = EntityManager.Instance.Get(configID, EntityID++,eCamp.Enemy);

        enemy.Pos = GameManager.MainPlayer.Pos + GameManager.MainPlayer.Forward*5;
        //enemy.SetAI("Monster");
    }

    void LoadFriend()
    {
        uint configID = configs[Random.Range(0, 3)];
        Entity enemy = EntityManager.Instance.Get(configID, EntityID++,eCamp.Friend);
        enemy.Pos = GameManager.MainPlayer.Pos + GameManager.MainPlayer.Forward;
        //enemy.SetAI("Monster");
    }

    void ChangeScene()
    {
        SceneManager.Instance.LoadScene("101");
    }
}
