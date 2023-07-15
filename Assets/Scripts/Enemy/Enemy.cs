using UnityEngine;
using EState;

public class Enemy : MonoBehaviour
{
    // 몬스터의 종류는 다 투사체형이며 캐논형, 저격형, 3연발형, 레이저형(엘리트)  4가지로 구현
    EnemyBase _EB;
    BulletBase _BB;
    EnemyState _state;
    MoveState _MV;
    Student _ST;

    Vector3 _initPostion;

    public bool isDie = false;
    public bool isHitted = false;


    int _enemyCount;

    public int EnemyCount { get { return _enemyCount; } set { _enemyCount = value; } }
    float _bulletDamage;
    public float BulletDamage { get { return _bulletDamage; } }
    public Define.Enemy EnemyStat { get { return _EB.getEnemyStat; } }
    public Define.EnemyType EnemyType { get { return _EB.getEnemyType; } }
    public EnemyBase sendEnemyBase { get { return _EB; } }
    public Vector3 InitPosition { get { return _initPostion; } }
    public MoveState MoveState { get { return _MV; } }


    private void Update()
    {
        if (_state == null)
        {
            _state = new RespawnState();
            _state.OnEnter(this);
        }
        if (_state != null) _state.MainLoop();
        Debug.Log("현재 상태 :" + _state);
    }

    public void init(EnemyBase EB)
    {
        _EB = EB;
    }

    public void init(Student ST)
    {
        _ST = ST;
    }

    public void ChangeUnitState(EnemyState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }

    public void init(MoveState MV)
    {
        _MV = MV;
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //총알과의 충돌처리 여기서 다 함 (종류 4가지, 레이저(엘리트), 포, 저격, 3연발) 레이저는 오브젝트의 라이프타임으로 사라짐을 조절
        if (collision.gameObject.tag == "Bullet")
        {
            isHitted= true;
        }

        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("충돌");
            _initPostion = transform.position;
            ChangeUnitState(new MoveState());


        }
    }
}