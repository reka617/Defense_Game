using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utils;

public abstract class BulletBase
{
    protected GameObject _obj;
    protected Define.EnemyBulletType _bType;

    public GameObject BulletObj { get { return _obj; } }

    public abstract void Init();
}

public class LaserShotBullet : BulletBase
{
    public override void Init()
    {
        _bType = Define.EnemyBulletType.Laser;
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}

public class ParabolaShotBullet : BulletBase
{
    public override void Init()
    {
        _bType = Define.EnemyBulletType.Parabola;
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}

public class ThreeShotBullet : BulletBase
{
    public override void Init()
    {
        _bType = Define.EnemyBulletType.ThreeShot;
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.GetComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 0, 0);
    }
}


public class StudentBullet : BulletBase
{
    public override void Init()
    {
        _obj = Managers.Resource.Instantiate("Bullet");
        _obj.AddComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 1, 0);
    }
}



