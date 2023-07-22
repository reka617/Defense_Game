using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Utils;

public class EnemyBulletFire : MonoBehaviour
{
    Transform target;
    Define.EnemyBulletType _bulletType;

    float firingAngle = 30f;
    float gravity = 9.8f;


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
            //ParabolaShot();
            
        }
    }

    //void ParabolaShot()
    //{
    //    Vector3 tmp;

    //    tmp = transform.position;
    //    tmp.z -= 1;

    //    BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType);
    //    _bb.BulletObj.transform.position = tmp;
    //    //_bb.BulletObj.AddComponent<Parabola>();

    //    //_bb.BulletObj.GetComponent<Bullet>().ParabolaBulletMove();
    //    //Debug.Log("포물shot");
    //    Debug.Log("중복확인");
    //}



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

            //_bb.BulletObj.GetComponent<Bullet>().BulletMove();
            Debug.Log("발사");
            yield return new WaitForSeconds(1f);
        }

       
        yield return new WaitForSeconds(5f);
    }
}
