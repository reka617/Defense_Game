using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using Utils;

public class Enemy : MonoBehaviour
{
    // 몬스터의 종류는 다 투사체형이며 포물선으로 탄 쏘는형, 레이저 쏘는 형, 3연발 쏘는 형 3가지로 구현
    Transform _student;
    EnemyController _EC;
    SpriteRenderer _render;

    Vector3 posGoal;

    float _enemySpeed;
    int _enemyHP;

    public bool isDie = false;
    bool isHitted = false;

    public int _enemyCount;

    float _colorTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void init(EnemyController EC, Transform student)
    {
        isDie = false;
        _student = student;
        _EC = EC;
        _enemySpeed = 1;
        _enemyHP = 20;
        gameObject.SetActive(true);
        Vector3 ranPos = student.position + new Vector3(Random.Range(10f, 60f), 0, Random.Range(-15f, 15f));
        transform.position = ranPos;
        Debug.Log("적 생성");
    }

    /*void Live()
    {
        isDie = false;
    }

    void Move()
    {
    
    }*/

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
        _enemyHP -= hitPower;
        isHitted = true;
        if (_enemyHP <= 0)
        {
            IsDie();
        }
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