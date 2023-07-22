using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyBulletFire : MonoBehaviour
{
    Transform target;
    Define.EnemyBulletType _bulletType;

    float firingAngle = 45f;
    float gravity = 9.8f;

    public void Start()
    {
        target = GameObject.FindWithTag("Student").transform;
    }

    public void CheckAndFire()
    {
        if (GetComponent<Enemy>().EnemyType == Define.EnemyType.ThreeShotEnemy)
        {
            _bulletType = Define.EnemyBulletType.ThreeShot;
            Debug.Log("삼연발발사");
            StartCoroutine(CoThreeShot());  
        }

        if(GetComponent<Enemy>().EnemyType == Define.EnemyType.LaserEnemy) 
        {
            _bulletType = Define.EnemyBulletType.Laser;
            Debug.Log("레이저발사");
        }

        if(GetComponent<Enemy>().EnemyType == Define.EnemyType.ParabolaEnemy) 
        {
            _bulletType = Define.EnemyBulletType.Parabola;
            Debug.Log("포물탄환발사");
            StartCoroutine(CoParabolaShot());

            
        }
    }

    IEnumerator CoParabolaShot()
    {
        yield return new WaitForSeconds(2f);

        Vector3 tmp = transform.position;
        tmp.z -= 1;

        BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType);

        _bb.BulletObj.transform.position = tmp;

        float target_Distance = Vector3.Distance(_bb.BulletObj.transform.position, target.position);
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        float flightDuration = target_Distance / Vx;

        _bb.BulletObj.transform.rotation = Quaternion.LookRotation(target.position - _bb.BulletObj.transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            _bb.BulletObj.transform.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }

    IEnumerator CoThreeShot()
    {
        Vector3 tmp;
        int i = 0;

        tmp = transform.position;
        tmp.z -= 1;
        while (i < 3)
        {
            BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType);

            tmp.y += Random.Range(-0.1f, 0.1f);
            tmp.x += Random.Range(-0.1f, 0.1f);
            _bb.BulletObj.transform.position = tmp;
            i++;
            Debug.Log("발사");
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(5f);
    }
}
