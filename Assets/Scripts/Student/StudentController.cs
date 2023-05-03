using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{

    int LiveEnemyCount = 0;

    List<Enemy> enemyList = new List<Enemy>();
    

    bool isFindLiveEnemy(List<Enemy> enemies)
    {
        enemyList = enemies;
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.isDie)
            {
                LiveEnemyCount++;
            }
        }

        if (LiveEnemyCount == 0) return false;
        return true;
    }

    void StudentAutoShot()
    {
        if (!isFindLiveEnemy(enemyList)) return;

        //가장 근처 몹 찾아서 탄알 발사

    }
}
