using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class ThreeShot : MonoBehaviour
{
    Transform Target;
    Vector3 bulletStartPosition;
    Rigidbody _rig;

    Vector3 _dir;

    float bulletSpeed = 1;

    private void Start()
    {
        Target = GameObject.FindWithTag("Student").transform;
        _rig = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnEnable()
    {
        bulletStartPosition = GetComponent<Bullet>().EnemyCurrentPosition;
        ThreeShotMethod();
    }

    // Update is called once per frame
    private void Update()
    {
        _dir = (Target.position - transform.position).normalized;
        _rig.AddForce(_dir * bulletSpeed, ForceMode.Impulse);
    }

    public void ThreeShotMethod()
    {
        Vector3 tmp;
        transform.position = bulletStartPosition;
        tmp = transform.position;
        tmp.z -= 1;
        tmp.y += Random.Range(-0.1f, 0.1f);
        tmp.x += Random.Range(-0.1f, 0.1f);
        transform.position = tmp;
        Debug.Log("น฿ป็");
    }
}
