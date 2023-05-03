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
        // ��ȯ�� ��ġ���� ������ ���������� �̵�
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
        //�������� ������ �ϵ�, 3���� �������� �������� �����Ͽ� ������ ����
    }
}
