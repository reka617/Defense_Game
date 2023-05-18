using UnityEngine;
using EState;

public class Enemy : MonoBehaviour
{
    // ������ ������ �� ����ü���̸� ĳ����, ������, 3������, ��������(����Ʈ)  4������ ����

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

    

    private void OnCollisionEnter(Collision collision)
    {
        //�Ѿ˰��� �浹ó�� ���⼭ �� �� (���� 4����, ������(����Ʈ), ��, ����, 3����) �������� ������Ʈ�� ������Ÿ������ ������� ����
        if (collision.gameObject.name == "Bullet")
        {
            _bulletDamage = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            isHitted= true;
            //collision.gameObject.GetComponent<BulletRemove>().remove(); // ������ �浹���� �� ������Ʈ�� �����
        }
    }
}