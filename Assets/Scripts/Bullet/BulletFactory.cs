using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public BulletBase CreateBullet(Define.EnemyBulletType EBT)
    {
        Init();
        BulletBase bb = bFactories[(int)EBT].MakeBullet();
        return bb;
    }
}

public abstract class BulletFactoryBase
{
    protected Student _ST;
    public BulletFactoryBase()
    {
        _ST = GameObject.Find("Student_Root").GetComponent<Student>();
    }
    public abstract BulletBase MakeBullet();
}

public class LaserShotBulletFactory : BulletFactoryBase 
{
    public override BulletBase MakeBullet() 
    {
        BulletBase bul = new LaserShotBullet();
        bul.Init(_ST);
        return bul;
    }
}

public class ParabolaShotBulletFactory : BulletFactoryBase {
    public override BulletBase MakeBullet() 
    {
        BulletBase bul = new ParabolaShotBullet();
        bul.Init(_ST);
        return bul;
    }
}

public class ThreeShotBulletFactory : BulletFactoryBase
{
    public override BulletBase MakeBullet()
    {
        BulletBase bul = new ThreeShotBullet();
        bul.Init(_ST);
        return bul;
    }
}


