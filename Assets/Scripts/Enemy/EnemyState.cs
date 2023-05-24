using UnityEngine;
using EState;
using UnityEngine.UIElements;
using Define;

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
        bool isAttack = false;
        bool isLeft = true;
        bool isRight = false;
        float moveMax = 2.0f;
        float dTime = 0;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            _enemy.init(this);
        }

        public override void MainLoop()
        {
            _isHitted = _enemy.isHitted;
            // ��ȯ�� ��ġ���� ������ ���������� �̵� //�¿�� �̵��� ���ؼ� x��ǥ�� ��Ʈ��// �� ��Ʈ�� ����
            Vector3 v = _enemy.InitPosition;
            if (_enemy.transform.position.x > v.x + moveMax)
            {
                if (!isAttack)
                {
                    isAttack = true;
                    _enemy.ChangeUnitState(new AttackState());
                    _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
                }
                else if (isAttack)
                {
                    isRight = false;
                    isLeft = true;
                    dTime += Time.deltaTime;
                    if (dTime > 5)
                    {
                        _enemy.transform.Translate(Vector3.left * Time.deltaTime);
                        isAttack = false;
                        dTime = 0;
                    }
                }
            }
            else if (_enemy.transform.position.x < v.x - moveMax)
            {
                if (!isAttack)
                {
                    isAttack = true;
                    _enemy.ChangeUnitState(new AttackState());
                    _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
                }
                else if (isAttack)
                {
                    isLeft = false;
                    isRight = true;
                    dTime += Time.deltaTime;
                    if (dTime > 5)
                    {
                        _enemy.transform.Translate(Vector3.right * Time.deltaTime);
                        isAttack = false;
                        dTime = 0;
                    }
                }
            }
            else
            {
                if (isLeft && !isAttack)
                {
                    _enemy.transform.Translate(Vector3.left * Time.deltaTime);
                }
                else if(isRight && !isAttack)
                {
                    _enemy.transform.Translate(Vector3.right * Time.deltaTime);
                }
            }

            //�¾��� �� �������·� ��ȯ �׷��� �¾Ҵٰ��ؼ� �̵��� �������� ����, �̵��� �������ϰ� ������ȯ
            if (_isHitted == true)
            {
                {
                    _enemy.ChangeUnitState(new HittedEnemyState());
                }
            }
        }
        // ������ �������� �� ���ӿ�����Ʈ�� �����ؼ� �־���°ŷ�

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
            Debug.Log("����");
            _enemy.ChangeUnitState(_enemy.MoveState);
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



