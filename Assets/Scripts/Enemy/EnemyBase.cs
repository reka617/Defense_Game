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
        //_eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.SniperEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("SniperEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>()._enemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class CannonEnemy : EnemyBase
{
    public override void Init()
    {
       // _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.CannonEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("CannonEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>()._enemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class ThreeShotEnemy : EnemyBase
{
    public override void Init()
    {
      //  _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.ThreeShotEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("ThreeShotEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>()._enemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}

public class EliteEnemy : EnemyBase
{
    public override void Init()
    {
      //  _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.EliteEnemy);
        _eType = Define.EnemyType.SniperEnemy;
        _obj = Managers.Resource.Instantiate("EliteEnemy");
        _obj.GetComponent<Enemy>().init(this);
        _obj.GetComponent<Enemy>()._enemyCount++;
        _obj.transform.position = new Vector3(Random.Range(-10f, 10f), 20f, Random.Range(10f, 60f));
    }
}
