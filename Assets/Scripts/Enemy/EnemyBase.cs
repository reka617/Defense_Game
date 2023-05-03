using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyBase
{
    protected GameObject _obj;
    protected Define.Enemy _eStat;
    protected Define.EnemyType _eType;

    public Define.EnemyType getEnemyType { get { return _eType; } }
    public Define.Enemy getEnemyStat { get { return _eStat; } }

    public abstract void Init();
}

public class SniperEnemy : EnemyBase
{
    public override void Init()
    {
        _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.SniperEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("SniperEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.transform.position = new Vector3(0, 0.5f, 0); // 몬스터 리젠 위치 지정(오른쪽이나 왼쪽으로 생성)
    }
}

public class CannonEnemy : EnemyBase
{
    public override void Init()
    {
        _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.CannonEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("CannonEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.transform.position = new Vector3(0, 0.5f, 0); // 몬스터 리젠 위치 지정(오른쪽이나 왼쪽으로 생성)
    }
}

public class ThreeShotEnemy : EnemyBase
{
    public override void Init()
    {
        _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.ThreeShotEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("ThreeShotEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.transform.position = new Vector3(0, 0.5f, 0); // 몬스터 리젠 위치 지정(오른쪽이나 왼쪽으로 생성)
    }
}

public class EliteEnemy : EnemyBase
{
    public override void Init()
    {
        _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.EliteEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("EliteEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.transform.position = new Vector3(0, 0.5f, 0); // 몬스터 리젠 위치 지정(오른쪽이나 왼쪽으로 생성)
    }
}
