using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyBulletFire : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Enemy>().sendEnemyBase.getEnemyType == Define.EnemyType.ThreeShotEnemy)
        {
            Debug.Log("น฿ป็");
            StartCoroutine(CoThreeShot());

        }
    }

    IEnumerator CoThreeShot()
    {
        int i = 0;
        while (i < 3)
        {
            GenericSingleton<BulletFactory>.getInstance().ThreeShotFire();
            i++;
        }
        yield return new WaitForSeconds(5f);
    }
}
