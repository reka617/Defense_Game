using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{

    protected Enemy _enemy;

    public virtual void OnEnter(Enemy enemy)
    {
        _enemy = enemy;
    }

    public virtual void MainLoop()
    {

    }
}

public class MoveState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        base.OnEnter(enemy);
    }

    public override void MainLoop()
    {
        // 소환된 위치에서 지정된 포지션으로 이동
    }
}

public class HittedState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        base.OnEnter(enemy);
    }

    public override void MainLoop()
    {
        //_enemyHP -= hitPower;
        //isHitted = true;
        //if (_enemyHP <= 0)
        //{
        //    IsDie();
        //}
    }
}

public class AttackState : EnemyState
{
    public override void OnEnter(Enemy enemy)
    {
        base.OnEnter(enemy);
    }

    public override void MainLoop()
    {
        //유저한테 공격을 하되, 3개의 포지션을 랜덤으로 결정하여 공격을 가함
    }
}
