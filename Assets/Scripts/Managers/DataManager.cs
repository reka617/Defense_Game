using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;



public class DataManager
{
    private Dictionary<Define.StudentType, Define.Student> _studentDict;
    private Dictionary<Define.EnemyType, Define.Enemy> _enemyDict;
    public void Init()
    {
        //_studentDict = ReadJson.LoadJsonDict<Define.StudentType, Define.Student>("Data/StudentData");
        //_enemyDict = ReadJson.LoadJsonDict<Define.EnemyType, Define.Enemy>("Data/EnemyData");
    }

    public Define.Student GetStudentInfo(Define.StudentType studentType)
    {
        return _studentDict[studentType];
    }
    public Define.Enemy GetEnemyInfo(Define.EnemyType enemyType)
    {
        return _enemyDict[enemyType];
    }
}
