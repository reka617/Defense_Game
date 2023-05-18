using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    List<EnemyFactoryBase> eFactories = new List<EnemyFactoryBase>();
    void Init()
    {
        if (eFactories.Count > 0) return;
        eFactories.Add(new SniperEnemyFactory());
        eFactories.Add(new CannonEnemyFactory());
        eFactories.Add(new ThreeShotEnemyFactory());
        eFactories.Add(new EliteEnemyFactory());
    }

    public EnemyBase SummonEnemy()
    {
        Init();
        int i = Random.Range(0, eFactories.Count - 2);
        return eFactories[i].MakeEnemy();
    }
}

public abstract class EnemyFactoryBase
{

    public abstract EnemyBase MakeEnemy();
}

public class SniperEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new SniperEnemy();
        mon.Init();
        return mon;
    }
}

public class CannonEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new CannonEnemy();
        mon.Init();
        return mon;
    }
}

public class ThreeShotEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new ThreeShotEnemy();
        mon.Init();
        return mon;
    }
}

public class EliteEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new EliteEnemy();
        mon.Init();
        return mon;
    }
}