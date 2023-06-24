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
            StartCoroutine(CoThreeShot());  
            

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

            _bb.BulletObj.GetComponent<Bullet>();
            tmp.y += Random.Range(-0.1f, 0.1f);
            tmp.x += Random.Range(-0.1f, 0.1f);
            _bb.BulletObj.transform.position = tmp;
            i++;
            Debug.Log("น฿ป็");
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(5f);
    }
}
