using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using Utils;

public class Enemy : MonoBehaviour
{
    // ������ ������ �� ����ü���̸� ���������� ź �����, ������ ��� ��, 3���� ��� �� 3������ ����
    Transform _student;
    EnemyController _EC;
    SpriteRenderer _render;


    EnemyBase _EB;
    EnemyState _state;

    Vector3 posGoal;

    float _enemySpeed;
    int _enemyHP;

    public bool isDie = false;
    bool isHitted = false;

    public int _enemyCount;

    float _colorTimer = 0f;

    public 


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

    public void init(EnemyBase EB, Transform student)
    {
        _studentPosition = student;
        _EB = EB;
        gameObject.SetActive(true);
        Vector3 ranPos = student.position + new Vector3(Random.Range(10f, 60f), 0, Random.Range(-15f, 15f));
        transform.position = ranPos;
        Debug.Log("�� ����");
    }

    public void ChangeUnitState(EnemyState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }



    void ChangeHitColor()
    {
        if (isHitted == true)
        {
            _colorTimer += Time.deltaTime;
            _render.color = Color.red;
            if (_colorTimer > 0.1f)
            {
                isHitted = false;
                _render.color = Color.white;
                _colorTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            int BD = collision.gameObject.GetComponent<BulletDamage>().getDamage();
            onHitted(BD);
            //collision.gameObject.GetComponent<BulletRemove>().remove();

        }
    }

    void onHitted(int hitPower)
    {
       
    }

    public void IsDie()
    {
        isDie = true;
        gameObject.SetActive(false);

    }

    //IEnumerator Roaming()
    //{
    //    while(true)
    //    {
    //        posGoal = new Vector3(0, 0, Random.Range(-5f, 5f));
            
    //    }
        
    //}
}

public class IdleEnemy : State
{
    public override void OnEnter()
    {
        
    }
}

public class AttackEnemy : State
{
    public override void OnEnter()
    {
        
    }
}

public class DIeEnemy : State
{
    public override void OnEnter()
    {
        
    }
}

public enum EnemyStat
{
    None,
    Damage,
    Hp,
    Enemy,
    Max
}

public enum EnemyType
{
    None,
    Normal,
    Elite,
    Max
}