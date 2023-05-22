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

    public class RespawnState : EnemyState
    {
        bool _respawn = false;
        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
        }

        public override void MainLoop()
        {

        }
    }

    public class MoveState : EnemyState
    {
        bool _isHitted = false;
        Vector3 _nowPosition;
        float moveMax = 2.0f;
        float moveSpeed = 3.0f;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            _nowPosition = _enemy.transform.position;
        }

        public override void MainLoop()
        {

            _isHitted = _enemy.isHitted;
            // 소환된 위치에서 지정된 포지션으로 이동 //좌우로 이동을 위해서 x좌표로 패트롤// 적 패트롤 구현
            //Vector3 v = _nowPosition;
            //v.x = _nowPosition.x + (moveMax * Mathf.Sin(Time.time * moveSpeed));
            //_enemy.transform.position = v;
            //if(_enemy.transform.position.x >= _nowPosition.x + moveMax)
            //{
            //    _enemy.ChangeUnitState(new AttackState());
            //}
            //else if(_enemy.transform.position.x <= _nowPosition.x + -moveMax)
            //{
            //    _enemy.ChangeUnitState(new AttackState());
            //}

            //맞았을 떄 맞은상태로 전환 그러나 맞았다고해서 이동을 안하지는 않음, 이동을 끝까지하고 상태전환
            if (_isHitted == true)
            {
                {
                    _enemy.ChangeUnitState(new HittedEnemyState());
                }
            }
        }
        // 지정된 포지션은 빈 게임오브젝트를 생성해서 넣어놓는거로

    }
}


    public class HittedEnemyState : EnemyState
    {
        SpriteRenderer _render;
        float _hp;
        bool _isHitted;
        float _colorTimer = 0f;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
        }

        public override void MainLoop()
        {
            _isHitted = _enemy.isHitted;
            _hp = _enemy.EnemyStat.hp;
            _hp -= _enemy.BulletDamage;
            _isHitted = true;
            if (_hp <= 0)
            {
                _enemy.ChangeUnitState(new DieState());
            }
            ChangeHitColor();
            _enemy.ChangeUnitState(new MoveState());
        }
        void ChangeHitColor()
        {
            if (_isHitted == true)
            {
                _colorTimer += Time.deltaTime;
                _render.color = Color.red;
                if (_colorTimer > 0.1f)
                {
                    _isHitted = false;
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
            Debug.Log("공격");
            _enemy.ChangeUnitState(new MoveState());
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



