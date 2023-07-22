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
            Debug.Log("�￬�߹߻�");
            StartCoroutine(CoThreeShot());  
        }

        if(GetComponent<Enemy>().EnemyType == Define.EnemyType.LaserEnemy) 
        {
            _bulletType = Define.EnemyBulletType.Laser;
            Debug.Log("�������߻�");
        }

        if(GetComponent<Enemy>().EnemyType == Define.EnemyType.ParabolaEnemy) 
        {
            _bulletType = Define.EnemyBulletType.Parabola;
            Debug.Log("����źȯ�߻�");
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
    //    //Debug.Log("����shot");
    //    Debug.Log("�ߺ�Ȯ��");
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
            Debug.Log("�߻�");
            yield return new WaitForSeconds(1f);
        }

       
        yield return new WaitForSeconds(5f);
    }
}
