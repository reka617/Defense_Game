using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform _studentPosition;

   
    int enemyCount;

    List<Enemy> enemies = new List<Enemy>();



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GenericSingleton<EnemyFactory>.getInstance().SummonEnemy();
        }
    }

    //���� ����� ��ġ�� �ִ� ���� ã�� �Լ�

   
  
    // ���Ͱ� �� �׾����� Ȯ���ϱ� ���� �Լ�
    void checkEnemyCount()
    {
       
    }



}
