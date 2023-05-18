using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    protected GameObject _obj;
    

    void Init()
    {
        _obj = Managers.Resource.Instantiate("EnemyBullet");
        _obj.AddComponent<Bullet>().Init(this);
        _obj.transform.position = new Vector3(0, 1, 0);
    }

    IEnumerator CoThreeShot(int bulletCount)
    {
        int i=0;
        while (i<bulletCount)
        {
            Init();
            i++;
            yield return new WaitForSeconds(2f);
        }
    }


}
