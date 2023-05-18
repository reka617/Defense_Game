using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    DateTime _OnButtonTime;
    float _accTime;
    float _neglectExp;
    float _neglectExpMag = 1.2f; // 임시로 1.2 넣음, 배율 정해지면 데이터로 집어넣음
    //버튼 눌렀을 떄 재화 초기화, 시간 다시 체크
    //누적될 수 있는 최대 재화량은 레벨에 따라 정해지고 최대가 됬을 경우 재화는 더 이상 오르지 않음 


 
    public void ClickTakeButton()
    {
        //재화 받은거 창고에 저장
        //계정 경험치 반영
        //시간 다시 체크 
        AddAccountExp();
        AddUseItem();
        _OnButtonTime = DateTime.Now; // 보상받은 시간을 체크 //파일로 저장
    }

    void AddAccountExp()
    {
        _accTime = (float)(DateTime.Now - _OnButtonTime).TotalSeconds;
        // 내 계정 경험치에 얻은 경험치 집어넣기
        //시간에 따른 경험치 비율 30분에 1퍼 (MAx경험치 만들어놓고, 1퍼비율 정한뒤 주어지는 경험치 비율 넣기)
        _neglectExp = ((_accTime / 10)) * _neglectExpMag; //확인하기 좋게 임시로 10초로 나눔
        Debug.Log("경험치 넣음" + _neglectExp);
    }
    
    void AddUseItem() // 레벨비율과 시간의 흐름의 비율을 생각해서 주는 아이템의 보상폭을 올림 ex) 1레벨엔 10경험치책주다가 2레벨엔 20경험치 책 주는 느낌
    {

    }

    private void OnDisable()
    {
       
    }
}
