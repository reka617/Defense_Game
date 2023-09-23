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
            // 소환된 위치에서 지정된 포지션으로 이동 //좌우로 이동을 위해서 x좌표로 패트롤// 적 패트롤 구현
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
                    Debug.Log("지정포인트가 아닙니다.");
                }
                if (!isAttack)
                {
                    Debug.Log("공격상태로변화");
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
        //            Debug.Log("오른쪽 끝, 공격시작");
        //            isAttack = true;
        //            _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
        //            _enemy.ChangeUnitState(new AttackState());
        //        }
        //        else if (isAttack)
        //        {
        //            Debug.Log("공격끝, 왼쪽으로 이동");
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
        //            Debug.Log("왼쪽 끝, 공격시작");
        //            isAttack = true;
        //            _enemy.ChangeUnitState(new AttackState());
        //            _enemy.transform.Translate(Vector3.zero * Time.deltaTime);
        //        }
        //        else if (isAttack)
        //        {
        //            Debug.Log("공격끝, 오른쪽으로 이동");
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

        //    //맞았을 떄 맞은상태로 전환 그러나 맞았다고해서 이동을 안하지는 않음, 이동을 끝까지하고 상태전환
        //    if (_isHitted == true)
        //    {
        //        {
        //            _enemy.ChangeUnitState(new HittedEnemyState());
        //        }
        //    }
        //}
        // 지정된 포지션은 빈 게임오브젝트를 생성해서 넣어놓는거로

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
                Debug.Log("공격");
            }
            dTime -= Time.deltaTime;

            if (dTime <= 0)
            {
                isFire = false;
                Debug.Log("공격완료");
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
            //죽는 애니메이션 실행
            Managers.Resource.Destroy(_enemy.gameObject);
            _enemy.EnemyCount++;
        }
    }
}




