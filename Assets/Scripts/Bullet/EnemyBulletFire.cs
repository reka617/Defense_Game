using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyBulletFire : MonoBehaviour
{
    Define.EnemyBulletType _bulletType;

    // Update is called once per frame
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

            Vector3 tmp = transform.position;
            tmp.z -= 1;

            BulletBase _bb = GenericSingleton<BulletFactory>.getInstance().CreateBullet(_bulletType);

            _bb.BulletObj.transform.position = tmp;
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
            Debug.Log("�߻�");
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(5f);
    }
}
