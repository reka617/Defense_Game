using UnityEngine;
using EState;
using Define;

public class Enemy : MonoBehaviour
{
    // ������ ������ �� ����ü���̸� ĳ����, ������, 3������, ��������(����Ʈ)  4������ ����

    EnemyBase _EB;
    EnemyState _state;
    MoveState _MV;

    Vector3 _initPostion;

    public bool isDie = false;
    public bool isHitted = false;
    public int _enemyCount;

    float _bulletDamage;
    public float BulletDamage { get { return _bulletDamage; } }
    public Define.Enemy EnemyStat { get { return _EB.getEnemyStat; } }
    public EnemyBase sendEnemyBase { get { return _EB; } }
    public Vector3 InitPosition { get { return _initPostion; } }
    public MoveState MoveState { get { return _MV; } }


    // Update is called once per frame
    void Update()
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
            _bulletDamage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            isHitted= true;
            //collision.gameObject.GetComponent<BulletRemove>().remove(); // ������ �浹���� �� ������Ʈ�� �����
        }

        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("�浹");
            _initPostion = transform.position;
            ChangeUnitState(new MoveState());


        }
    }
}