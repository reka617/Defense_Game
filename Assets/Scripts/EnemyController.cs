using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    Transform _unit;
    GameObject _enemy;

    List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makeEnemy()
    {

        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(_enemy, transform);
            enemies.Add(enemy.GetComponent<Enemy>());
        }

        foreach (Enemy enemy in enemies)
        {
            enemy.init(this, _unit);

        }
    }
}
