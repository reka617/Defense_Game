using UnityEngine;
using EState;

public class Enemy : MonoBehaviour
{
    // ������ ������ �� ����ü���̸� ĳ����, ������, 3������, ��������(����Ʈ)  4������ ����
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
        Debug.Log("���� ���� :" + _state);
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
        //�Ѿ˰��� �浹ó�� ���⼭ �� �� (���� 4����, ������(����Ʈ), ��, ����, 3����) �������� ������Ʈ�� ������Ÿ������ ������� ����
        if (collision.gameObject.tag == "Bullet")
        {
            isHitted= true;
        }

        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("�浹");
            _initPostion = transform.position;
            ChangeUnitState(new MoveState());


        }
    }
}