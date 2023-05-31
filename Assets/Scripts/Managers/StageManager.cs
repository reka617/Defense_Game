using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] GameObject _stageUI;
    [SerializeField] GameObject _stageClear;
    [SerializeField] GameObject _stageFail;
    [SerializeField] GameController _GC;
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
        //if(_EC.EnemyCount == 0)
        //{
        //    _stageClear.SetActive(true);
        //}
    }

    void StageFail()
    {
        _stageUI.SetActive(true);
        _stageFail.SetActive(true);
    }
}
