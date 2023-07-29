using System.Collections;
using UnityEngine;
using Utils;

public class EnemyBulletFire : MonoBehaviour
{
    Define.EnemyBulletType _bulletType;
    Transform Target;
    Enemy _E;
    float firingAngle = 45f;
    float gravity = 9.8f;

    private void Awake()
    {
        Target = GameObject.FindWithTag("Student").transform;
    }

    private void Update()
    {
        _E = GetComponent<Enemy>();
    }
    public void CheckAndFire()
    {
        if (GetComponent<Enemy>().EnemyType == Define.EnemyType.ThreeShotEnemy)
        {
            _bulletType = Define.EnemyBulletType.ThreeShot;

            Debug.Log("삼연발발사");
            for (int i = 0; i < 3; i++)
            {
                GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType, _E);
            }
            //StartCoroutine(CoThreeShot());  
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

            Vector3 tmp = transform.position;
            tmp.z -= 1;

            BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType, _E);

            _bb.BulletObj.transform.position = tmp;
           StartCoroutine(CoParabolaShot(_bb.BulletObj.transform));
        }
    }


   
    //IEnumerator CoThreeShot()
    //{
    //    Vector3 tmp;
    //    int i = 0;

    //    tmp = transform.position;
    //    tmp.z -= 1;
    //    while (i < 3)
    //    {
    //        BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType);
    //        tmp.y += Random.Range(-0.1f, 0.1f);
    //        tmp.x += Random.Range(-0.1f, 0.1f);
    //        _bb.BulletObj.transform.position = tmp;
    //        i++;
    //        Debug.Log("발사");
    //        yield return new WaitForSeconds(1f);
    //    }

       
    //    yield return new WaitForSeconds(5f);
    //}

    IEnumerator CoParabolaShot(Transform Projectile)
    { 
        Projectile.position = transform.position + new Vector3(0, 0.0f, 0);


        float target_Distance = Vector3.Distance(Projectile.position, Target.position); 


        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);


        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        float flightDuration = target_Distance / Vx;

        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }

}
