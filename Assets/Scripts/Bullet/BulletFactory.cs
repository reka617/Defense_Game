using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BulletBase;

public class BulletFactory : MonoBehaviour
{
    List<BulletFactoryBase> bFactories = new List<BulletFactoryBase>();
    void Init()
    {
        if (bFactories.Count > 0) return;
        bFactories.Add(new LaserShotBulletFactory());    
        bFactories.Add(new ParabolaShotBulletFactory());
        bFactories.Add(new ThreeShotBulletFactory());
       
    }

    public BulletBase CreateBullet(Define.EnemyBulletType EBT, Enemy enemy)
    {
        Init();
        BulletBase bb = bFactories[(int)EBT].MakeBullet(enemy);
        return bb;
    }
}

public abstract class BulletFactoryBase
{
    public abstract BulletBase MakeBullet(Enemy enemy);
}

public class LaserShotBulletFactory : BulletFactoryBase 
{
    public override BulletBase MakeBullet(Enemy enemy) 
    {
        BulletBase bul = new LaserShotBullet();
        bul.Init(enemy);
        return bul;
    }
}

public class ParabolaShotBulletFactory : BulletFactoryBase {
    public override BulletBase MakeBullet(Enemy enemy) 
    {
        BulletBase bul = new ParabolaShotBullet();
        bul.Init(enemy);
        return bul;
    }
}

public class ThreeShotBulletFactory : BulletFactoryBase
{
    public override BulletBase MakeBullet(Enemy enemy)
    {
        BulletBase bul = new ThreeShotBullet();
        bul.Init(enemy);
        return bul;
    }
}


