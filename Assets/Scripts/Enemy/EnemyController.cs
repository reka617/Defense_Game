using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform _studentPosition;

    int enemyCount;

    List<Enemy> enemies = new List<Enemy>();



    // Update is called once per frame
    void Update()
    {

    }

    //가장 가까운 위치에 있는 적을 찾는 함수
    public Transform selectEnemy()
    {
        float distance = 60f;
        Transform target = null;
        foreach (Enemy enemy in enemies)
        {
            if (distance >= Vector3.Distance(enemy.transform.position, _studentPosition.position) || target == null)
            {
                distance = Vector3.Distance(enemy.transform.position, _studentPosition.position);
                target = enemy.transform;
            }
        }
        return target;
    }
    // 몬스터가 다 죽었는지 확인하기 위한 함수
    void checkEnemyCount()
    {
       
    }



}
