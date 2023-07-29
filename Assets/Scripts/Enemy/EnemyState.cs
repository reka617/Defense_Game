using UnityEngine;
using EState;
using UnityEngine.UIElements;
using Define;
using Utils;
using TMPro;

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
        //bool isLeft = true;
        //bool isRight = false;
        float moveMax = 2.0f;
        float waitTime = 0;
        float startTime = 5;
        Vector3 initSpot;
        Vector3[] moveSpot;
        Vector3 curSpot;

        int i;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            _enemy.init(this);
            waitTime = startTime;
            initSpot = _enemy.InitPosition;
            moveSpot[0] = initSpot;
            moveSpot[1] = initSpot;
            moveSpot[1].x += moveMax;
            i = 0;
        }

        public override void MainLoop()
        {
            _isHitted = _enemy.isHitted;
            // ��ȯ�� ��ġ���� ������ ���������� �̵� //�¿�� �̵��� ���ؼ� x��ǥ�� ��Ʈ��// �� ��Ʈ�� ����
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, moveSpot[i], _enemy.enemySpeed * Time.deltaTime);

            if (Vector3.Distance(_enemy.transform.position, moveSpot[i]) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    if (i == 0)
                        i = 1;
                    else
                        i = 0;
                    waitTime = startTime;
                    isAttack = false;
                }
                else
                {
                    if (!isAttack)
                    {
                        isAttack = true;
                       _enemy.ChangeUnitState(new AttackState());
                    }
                    waitTime -= Time.deltaTime;
                }
            }

            //    if (_enemy.transform.position.x > v.x + moveMax)
            //    {
            //        if (!isAttack)
            //        {
            //            Debug.Log("������ ��, ���ݽ���");
            //            isAttack = true;
            //            _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
            //            _enemy.ChangeUnitState(new AttackState());
            //        }
            //        else if (isAttack)
            //        {
            //            Debug.Log("���ݳ�, �������� �̵�");
            //            isRight = false;
            //            isLeft = true;
            //            dTime += Time.deltaTime;
            //            if (dTime > 5)
            //            {
            //                _enemy.transform.Translate(Vector3.left * Time.deltaTime);
            //                isAttack = false;
            //                dTime = 0;
            //            }
            //        }
            //    }
            //    else if (_enemy.transform.position.x < v.x - moveMax)
            //    {
            //        if (!isAttack)
            //        {
            //            Debug.Log("���� ��, ���ݽ���");
            //            isAttack = true;
            //            _enemy.ChangeUnitState(new AttackState());
            //            _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
            //        }
            //        else if (isAttack)
            //        {
            //            Debug.Log("���ݳ�, ���������� �̵�");
            //            isLeft = false;
            //            isRight = true;
            //            dTime += Time.deltaTime;
            //            if (dTime > 5)
            //            {
            //                _enemy.transform.Translate(Vector3.right * Time.deltaTime);
            //                isAttack = false;
            //                dTime = 0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (isLeft && !isAttack)
            //        {
            //            _enemy.transform.Translate(Vector3.left * Time.deltaTime);
            //        }
            //        else if (isRight && !isAttack)
            //        {
            //            _enemy.transform.Translate(Vector3.right * Time.deltaTime);
            //        }
            //    }

            //    //�¾��� �� �������·� ��ȯ �׷��� �¾Ҵٰ��ؼ� �̵��� �������� ����, �̵��� �������ϰ� ������ȯ
            //    if (_isHitted == true)
            //    {
            //        {
            //            _enemy.ChangeUnitState(new HittedEnemyState());
            //        }
            //    }
            //}
            // ������ �������� �� ���ӿ�����Ʈ�� �����ؼ� �־���°ŷ�

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
            float dTime = 5;
            public override void OnEnter(Enemy enemy)
            {
                base.OnEnter(enemy);
            }

            public override void MainLoop()
            {
                _enemy.GetComponent<EnemyBulletFire>().CheckAndFire();
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
                _enemy.EnemyCount++;
            }
        }
    }
}



