using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{

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
    public void init(Transform enemyTarget)
    {
        _target = enemyTarget;   
        _dir = (_target.position - transform.position).normalized;
    }

    public void init(Vector3 dir)
    {
        _dir = dir;
    }

    void bulletMove(Transform target)
    {
        transform.Translate(_dir * Time.deltaTime * bulletSpeed);
    }
}
