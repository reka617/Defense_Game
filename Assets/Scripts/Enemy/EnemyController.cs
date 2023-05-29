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

    //가장 가까운 위치에 있는 적을 찾는 함수

   
  
    // 몬스터가 다 죽었는지 확인하기 위한 함수
    void checkEnemyCount()
    {
       
    }



}
