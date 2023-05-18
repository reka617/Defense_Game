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
            //�Ѿ˰��� �浹ó�� ���⼭ �� �� (���� 4����, ������(����Ʈ), ��, ����, 3����) �������� ������Ʈ�� ������Ÿ������ ������� ����
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
            // ��ȯ�� ��ġ���� ������ ���������� �̵� //�¿�� �̵��� ���ؼ� x��ǥ�� ��Ʈ��
            _respawnPosition = _enemy.transform.position;
            _respawnPosition.y = 0;
            _nowPosition = _enemy.transform.position;
            _nowPosition.y = 0;
            _leftMaxPosition = _respawnPosition + (Vector3.left * 3);
            _rightMaxPosition = _respawnPosition + (Vector3.right * 3);

            if (_nowPosition.x > _leftMaxPosition.x && _nowPosition.x < _rightMaxPosition.x)
            {
                while (sec < 3) //�ƽ��������� ����� ������ Ż��
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


