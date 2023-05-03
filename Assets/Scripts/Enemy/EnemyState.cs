using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using EState;

namespace EState
{
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
            // ������ �������� �� ���ӿ�����Ʈ�� �����ؼ� �־���°ŷ�
        }
    }

    public class HittedEnemyState : EnemyState
    {
        SpriteRenderer _render;
        float _hp;
        bool isHitted = false;
        float _colorTimer = 0f;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
        }

        public override void MainLoop()
        {
            _hp = _enemy.EnemyStat.hp;
            _hp -= _enemy.BulletDamage;
            isHitted = true;
            if (_hp <= 0)
            {
                _enemy.ChangeUnitState(new DieState());
            }
            ChangeHitColor();
            _enemy.ChangeUnitState(new AttackState());
        }
        void ChangeHitColor()
        {
            if (isHitted == true)
            {
                _colorTimer += Time.deltaTime;
                _render.color = Color.red;
                if (_colorTimer > 0.1f)
                {
                    isHitted = false;
                    _render.color = Color.white;
                    _colorTimer = 0f;
                }
            }
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

    public class DieState : EnemyState
    {
        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
        }
        public override void MainLoop()
        {
            //�״� �ִϸ��̼� ����
            Managers.Resource.Destroy(_enemy.gameObject);
            _enemy._enemyCount++;
        }
    }
}

