using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        _eStat = Managers.Data.GetEnemyInfo(Define.EnemyType.SniperEnemy);
        _eType = Define.EnemyType.SniperEnemy;

    }
}

public class CannonEnemy : EnemyBase
{
    public override void Init()
    {

    }
}

public class ThreeShotEnemy : EnemyBase
{
    public override void Init()
    {

    }
}

public class EliteEnemy : EnemyBase
{
    public override void Init()
    {

    }
}
