using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject _stageClear;
    [SerializeField] GameObject _stageFail;
    [SerializeField] EnemyController _EC;
    // Start is called before the first frame update

    private void Start()
    {

    }
    private void Update()
    {
        StageClear();
    }
    void StageClear()
    {
        if(_EC.EnemyCount == 0)
        {
            _stageClear.SetActive(true);
        }
    }

    void StageFail()
    {
        _stageFail.SetActive(true);
    }
}