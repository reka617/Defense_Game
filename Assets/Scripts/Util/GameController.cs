using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform _studentPosition;
    public Transform Target { get { return _studentPosition; } }
    
    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
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