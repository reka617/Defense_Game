using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform _studentPosition;

    GameObject _enemy;
    Enemy _E;
    List<Enemy> enemies = new List<Enemy>();

    public int enemyCount;
    

    // Start is called before the first frame update
    void Start()
    {
        _enemy = Resources.Load("Prefabs/Enemy") as GameObject;
        makeEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        getReMainEnemy(_E);
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
            enemy.init(this, _studentPosition);
            enemyCount++;
        }
    }

    public void newMakeEnemy()
    {
        bool isNew = true;
        foreach (Enemy _enemy in enemies)
        {
            if (_enemy.gameObject.activeSelf == false)
            {
                _enemy.init(this, _studentPosition);
                isNew = false;
                break;
            }
        }
        if (isNew)
        {
            GameObject enemy = Instantiate(_enemy);
            enemy.GetComponent<Enemy>().init(this, _studentPosition);
            enemies.Add(enemy.GetComponent<Enemy>());
        }
    }

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

    void getReMainEnemy(Enemy E)
    {
        _E = E;
        enemyCount -= _E._enemyCount;
    }


}
