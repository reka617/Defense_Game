using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Cafe : MonoBehaviour
{
    DateTime _OnButtonTime;
    float _accTime;
    //��ư ������ �� ��ȭ �ʱ�ȭ, �ð� �ٽ� üũ
    //������ �� �ִ� �ִ� ��ȭ���� ������ ���� �������� �ִ밡 ���� ��� ��ȭ�� �� �̻� ������ ���� 


    public void ClickTakeButton()
    {
        //��ȭ ������ â�� ����
        //���� ����ġ �ݿ�
        //�ð� �ٽ� üũ 
        AddAccountExp();
        _OnButtonTime = DateTime.Now; // ������� �ð��� üũ
    }

    void AddAccountExp()
    {
        _accTime = (float)(DateTime.Now - _OnButtonTime).TotalSeconds;
        // �� ���� ����ġ�� ���� ����ġ ����ֱ�
        Debug.Log("����ġ ����");
    }

    private void OnDisable()
    {
       
    }
}
