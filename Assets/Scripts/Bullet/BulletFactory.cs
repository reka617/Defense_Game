using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    List<BulletFactoryBase> bFactories = new List<BulletFactoryBase>();
    void Init()
    {
        if (bFactories.Count > 0) return;
        bFactories.Add(new ThreeShotBulletFactory());    
        bFactories.Add(new ThreeShotBulletFactory());
        bFactories.Add(new ThreeShotBulletFactory());
       
    }

    public BulletBase CreateBullet(Define.EnemyBulletType EBT)
    {
        Init();
        return bFactories[(int)EBT].MakeBullet();
    }
}

public abstract class BulletFactoryBase
{
    protected GameController _GC;
    public BulletFactoryBase()
    {
        _GC = GameObject.Find("GameController").GetComponent<GameController>();
    }
    public abstract BulletBase MakeBullet();
}

public class ThreeShotBulletFactory : BulletFactoryBase
{

    public override BulletBase MakeBullet()
    {
        BulletBase bul = new ThreeShotBullet();
        bul.Init(_GC);
        return bul;
    }
}


