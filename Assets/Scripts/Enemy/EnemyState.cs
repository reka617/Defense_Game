using UnityEngine;
using EState;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
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
            _enemy.ChangeUnitState(new MoveState());
        }
        private void OnCollisionEnter(Collision collision)
        {
            //총알과의 충돌처리 여기서 다 함 (종류 4가지, 레이저(엘리트), 포, 저격, 3연발) 레이저는 오브젝트의 라이프타임으로 사라짐을 조절
            if (collision.gameObject.tag == "Ground")
            {
                _enemy.ChangeUnitState(new MoveState());   
            }
        }
    }

    public class MoveState : EnemyState
    {
        bool _isHitted = false;
        Vector3 _respawnPosition;
        Vector3 _nowPosition;
        Vector3 _leftMaxPosition;
        Vector3 _rightMaxPosition;
        public override void OnEnter(Enemy enemy)
        {
            base.OnEnter(enemy);
        }

        public override void MainLoop()
        {
            int sec = 0;
            _isHitted = _enemy.isHitted;
            // 소환된 위치에서 지정된 포지션으로 이동 //좌우로 이동을 위해서 x좌표로 패트롤
            _respawnPosition = _enemy.transform.position;
            _respawnPosition.y = 0;
            _nowPosition = _enemy.transform.position;
            _nowPosition.y = 0;
            _leftMaxPosition = _respawnPosition + (Vector3.left * 3);
            _rightMaxPosition = _respawnPosition + (Vector3.right * 3);

            if (_nowPosition.x > _leftMaxPosition.x && _nowPosition.x < _rightMaxPosition.x)
            {
                while (sec < 3) //맥스포지션을 벗어나면 루프문 탈출
                {
                    if (_enemy.transform.position.x < _leftMaxPosition.x) break;
                    _enemy.transform.Translate(Vector3.left);
                    sec++;
                }
                sec = 0;
            }
            else if (_nowPosition.x <= _leftMaxPosition.x)
            {
                while (sec < 6)
                {
                    if (_enemy.transform.position.x > _rightMaxPosition.x) break;
                    _enemy.transform.Translate(Vector3.right);
                    sec++;
                }
                sec = 0;
            }
            else if (_nowPosition.x >= _rightMaxPosition.x)
            {
                while (sec < 6)
                {
                    if (_enemy.transform.position.x > _rightMaxPosition.x) break;
                    _enemy.transform.Translate(Vector3.right);
                    sec++;
                }
                sec = 0;
            }
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
            _enemy.ChangeUnitState(new AttackState());
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


