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

    //���� ����� ��ġ�� �ִ� ���� ã�� �Լ�
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
    // ���Ͱ� �� �׾����� Ȯ���ϱ� ���� �Լ�
    void checkEnemyCount()
    {
       
    }



}
