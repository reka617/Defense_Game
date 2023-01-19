using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform _unitBox;

    GameObject _enemy;

    List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {
        _enemy = Resources.Load("Prefabs/Enemy") as GameObject;
        makeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void makeEnemy()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(_enemy, transform);
            enemies.Add(enemy.GetComponent<Enemy>());
        }

        foreach (Enemy enemy in enemies)
        {
            enemy.init(this, _unitBox);
        }
    }

    public void newMakeEnemy()
    {
        bool isNew = true;
        foreach (Enemy _enemy in enemies)
        {
            if (_enemy.gameObject.activeSelf == false)
            {
                _enemy.init(this, _unitBox);
                isNew = false;
                break;
            }
        }
        if (isNew)
        {
            GameObject enemy = Instantiate(_enemy);
            enemy.GetComponent<Enemy>().init(this, _unitBox);
            enemies.Add(enemy.GetComponent<Enemy>());
        }
    }

    public Transform selectEnemy()
    {
        float distance = 0f;
        Transform target = null;
        foreach (Enemy enemy in enemies)
        {
            if (distance <= Vector3.Distance(enemy.transform.position, _unitBox.position) || target == null)
            {
                distance = Vector3.Distance(enemy.transform.position, _unitBox.position);
                target = enemy.transform;
            }
        }
        return target;
    }

}
