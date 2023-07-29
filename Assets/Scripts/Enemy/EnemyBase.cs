using UnityEngine;

public abstract class EnemyBase
{
    protected GameObject _obj;
    protected Define.Enemy _eStat;
    protected Define.EnemyType _eType;

    public Define.EnemyType getEnemyType { get { return _eType; } }
    public Define.Enemy getEnemyStat { get { return _eStat; } }
    public Vector3 getEnemyPosition { get { return _obj.transform.position; } }

    public abstract void Init();
}

public class LaserEnemy : EnemyBase
{
    public override void Init()
    {
        //_eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.SniperEnemy);
        _eType = Define.EnemyType.LaserEnemy;
        _obj = Managers.Resource.Instantiate("LaserEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>().EnemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class ParabolaEnemy : EnemyBase
{
    public override void Init()
    {
       // _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.CannonEnemy);
        _eType = Define.EnemyType.ParabolaEnemy;
        _obj = Managers.Resource.Instantiate("RockMob");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>().EnemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class ThreeShotEnemy : EnemyBase
{
    public override void Init()
    {
      //  _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.ThreeShotEnemy);
        _eType = Define.EnemyType.ThreeShotEnemy;
        _obj = Managers.Resource.Instantiate("WaterMob");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>().EnemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class EliteEnemy : EnemyBase
{
    public override void Init()
    {
        //  _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.EliteEnemy);
        _eType = Define.EnemyType.EliteEnemy;
        _obj = Managers.Resource.Instantiate("EliteEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>().EnemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}
