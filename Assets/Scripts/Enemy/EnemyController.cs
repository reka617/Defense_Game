using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform _studentPosition;

    Vector3 _target;
    int enemyCount;

    public Vector3 Target { get { return _target; } }
    
    List<Enemy> enemies = new List<Enemy>();
    private void Start()
    {
        _target = _studentPosition.position;
    }


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
