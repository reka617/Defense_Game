using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    DateTime _OnButtonTime;
    float _accTime;
    //버튼 눌렀을 떄 재화 초기화, 시간 다시 체크
    //누적될 수 있는 최대 재화량은 레벨에 따라 정해지고 최대가 됬을 경우 재화는 더 이상 오르지 않음 


    public void ClickTakeButton()
    {
        //재화 받은거 창고에 저장
        //계정 경험치 반영
        //시간 다시 체크 
        AddAccountExp();
        _OnButtonTime = DateTime.Now; // 보상받은 시간을 체크
    }

    void AddAccountExp()
    {
        _accTime = (float)(DateTime.Now - _OnButtonTime).TotalSeconds;
        // 내 계정 경험치에 얻은 경험치 집어넣기
        Debug.Log("경험치 넣음");
    }

    private void OnDisable()
    {
       
    }
}
