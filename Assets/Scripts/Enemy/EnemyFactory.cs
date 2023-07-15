using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    List<EnemyFactoryBase> eFactories = new List<EnemyFactoryBase>();
    void Init()
    {
        if (eFactories.Count > 0) return;
        eFactories.Add(new LaserEnemyFactory());
        eFactories.Add(new ParabolaEnemyFactory());
        eFactories.Add(new ThreeShotEnemyFactory());
        eFactories.Add(new EliteEnemyFactory());
    }

    public EnemyBase SummonEnemy()
    {
        Init();
        int i = Random.Range(0, eFactories.Count - 1);
        return eFactories[i].MakeEnemy();
    }
}

public abstract class EnemyFactoryBase
{

    public abstract EnemyBase MakeEnemy();
}

public class LaserEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new LaserEnemy();
        mon.Init();
        return mon;
    }
}

public class ParabolaEnemyFactory : EnemyFactoryBase
{
    public override EnemyBase MakeEnemy()
    {
        EnemyBase mon = new ParabolaEnemy();
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