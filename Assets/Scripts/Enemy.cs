using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Analytics;

public class Enemy : MonoBehaviour
{

    Transform _unitBox;
    EnemyController _EC;
    SpriteRenderer _render;

    Vector3 posGoal;

    float _enemySpeed;
    int _enemyHP;

    bool isDie = false;
    bool isHitted = false;

    float _colorTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init(EnemyController EC, Transform unitBox)
    {
        isDie = false;
        _unitBox = unitBox;
        _EC = EC;
        _enemySpeed = 1;
        _enemyHP = 20;
        gameObject.SetActive(true);
        Vector3 ranPos = _unitBox.position + new Vector3(Random.Range(-60f, -10f), 0, Random.Range(-15f, 15f));
        transform.position = ranPos;
        Debug.Log("Àû »ý¼º");
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
            isDie = true;
        }
    }

    //IEnumerator Roaming()
    //{
    //    while(true)
    //    {
    //        posGoal = new Vector3(0, 0, Random.Range(-5f, 5f));
            
    //    }
        
    //}
}
