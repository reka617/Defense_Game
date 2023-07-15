using UnityEngine;

public abstract class BulletBase
{
    protected GameObject _obj;
    protected Define.EnemyBulletType _bType;

    public GameObject BulletObj { get { return _obj; } }
    public Define.EnemyBulletType BType { get { return _bType; } }

    public abstract void Init(Student ST);
}

public class LaserShotBullet : BulletBase
{
    public override void Init(Student ST)
    {
        _bType = Define.EnemyBulletType.Laser;
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.GetComponent<Bullet>().Init(ST);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}

public class ParabolaShotBullet : BulletBase
{
    public override void Init(Student ST)
    {
        _bType = Define.EnemyBulletType.Parabola;
        _obj = Managers.Resource.Instantiate("ParabolaBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.GetComponent<Bullet>().Init(ST);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}

public class ThreeShotBullet : BulletBase
{
    public override void Init(Student ST)
    {
        _bType = Define.EnemyBulletType.ThreeShot;
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.GetComponent<Bullet>().Init(ST);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}


public class StudentBullet : BulletBase
{
    public override void Init(Student ST)
    {
        _obj = Managers.Resource.Instantiate("Bullet");
        _obj.AddComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 1, 0);
    }
}



