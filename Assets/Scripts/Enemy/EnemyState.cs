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
            // 소환된 위치에서 지정된 포지션으로 이동
            // 지정된 포지션은 빈 게임오브젝트를 생성해서 넣어놓는거로
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
            //유저한테 공격을 하되, 3개의 포지션을 랜덤으로 결정하여 공격을 가함
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
            //죽는 애니메이션 실행
            Managers.Resource.Destroy(_enemy.gameObject);
            _enemy._enemyCount++;
        }
    }
}

