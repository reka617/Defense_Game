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
       
    }

    public BulletBase ThreeShotFire()
    {
        Init();
        return bFactories[0].MakeBullet();
    }
}

public abstract class BulletFactoryBase
{
    public abstract BulletBase MakeBullet();
}

public class ThreeShotBulletFactory : BulletFactoryBase
{
    public override BulletBase MakeBullet()
    {
        BulletBase bul = new ThreeShotBullet();
        bul.Init();
        return bul;
    }
}


