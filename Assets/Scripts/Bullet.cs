using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    EnemyController EC;

    [SerializeField]
    float bulletSpeed;
    //target
    Transform _target = null;

    Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void init(EnemyController EC)
    {
        _target = EC.selectEnemy();   
        _dir = (_target.position - transform.position).normalized;
    }

    void bulletMove(Transform target)
    {
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
}
