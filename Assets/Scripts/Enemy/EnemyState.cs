using UnityEngine;
using EState;
using UnityEngine.UIElements;
using Define;
using Utils;
using TMPro;
using Unity.VisualScripting;

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
        float moveMax = 3.0f;
        float waitTime = 0;
        float startTime = 5;
        Vector3 initSpot;
        Vector3 waySpot;
        Vector3 nextSpot;

        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            _enemy.init(this);
            waitTime = startTime;
            initSpot = _enemy.InitPosition;
            waySpot = initSpot;
            waySpot.x += moveMax;
            nextSpot = waySpot;
        }

        public override void MainLoop()
        {
            _isHitted = _enemy.isHitted;
            // ��ȯ�� ��ġ���� ������ ���������� �̵� //�¿�� �̵��� ���ؼ� x��ǥ�� ��Ʈ��// �� ��Ʈ�� ����
            _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, nextSpot, _enemy.enemySpeed * Time.deltaTime);

            if (Vector3.Distance(_enemy.transform.position, nextSpot) < 0.1f)
            {
                if (Vector3.Distance(nextSpot, initSpot) < 0.1f)
                {
                    nextSpot = waySpot;
                }
                else if (Vector3.Distance(nextSpot, waySpot) < 0.1f)
                {
                    nextSpot = initSpot;
                }
                else
                {
                    Debug.Log("��������Ʈ�� �ƴմϴ�.");
                }
                if (!isAttack)
                {
                    Debug.Log("���ݻ��·κ�ȭ");
                    isAttack = true;
                    _enemy.ChangeUnitState(new AttackState());
                }
            }
            else
            {
                isAttack = false;
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
        bool isFire = false;
        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
            dTime = 5;
        }

        public override void MainLoop()
        {
            if (!isFire)
            {
                isFire = true;
                _enemy.GetComponent<EnemyBulletFire>().CheckAndFire();
                Debug.Log("����");
            }
            dTime -= Time.deltaTime;

            if (dTime <= 0)
            {
                isFire = false;
                Debug.Log("���ݿϷ�");
                _enemy.ChangeUnitState(_enemy.MoveState);
            }
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




