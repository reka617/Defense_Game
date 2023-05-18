using UnityEngine;
using EState;

public class Enemy : MonoBehaviour
{
    // 몬스터의 종류는 다 투사체형이며 캐논형, 저격형, 3연발형, 레이저형(엘리트)  4가지로 구현

    EnemyBase _EB;
    EnemyState _state;


    public bool isDie = false;
    public bool isHitted = false;
    public int _enemyCount;

    float _bulletDamage;
    public float BulletDamage { get { return _bulletDamage; } }
    public Define.Enemy EnemyStat { get { return _EB.getEnemyStat; } }

    // Update is called once per frame
    void Update()
    {
        if (_state == null)
        {
            _state = new MoveState();
            _state.OnEnter(this);
        }
        if (_state != null) _state.MainLoop();
        Debug.Log("현재 상태 :" + _state);
    }

    public void init(EnemyBase EB)
    {
        _EB = EB;
    }

    public void ChangeUnitState(EnemyState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //총알과의 충돌처리 여기서 다 함 (종류 4가지, 레이저(엘리트), 포, 저격, 3연발) 레이저는 오브젝트의 라이프타임으로 사라짐을 조절
        if (collision.gameObject.name == "Bullet")
        {
            _bulletDamage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            isHitted= true;
            //collision.gameObject.GetComponent<BulletRemove>().remove(); // 유저와 충돌했을 떄 오브젝트가 사라짐
        }
    }
}