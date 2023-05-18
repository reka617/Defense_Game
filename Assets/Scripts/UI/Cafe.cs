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
    float _neglectExpMag = 1.2f; // �ӽ÷� 1.2 ����, ���� �������� �����ͷ� �������
    //��ư ������ �� ��ȭ �ʱ�ȭ, �ð� �ٽ� üũ
    //������ �� �ִ� �ִ� ��ȭ���� ������ ���� �������� �ִ밡 ���� ��� ��ȭ�� �� �̻� ������ ���� 


 
    public void ClickTakeButton()
    {
        //��ȭ ������ â�� ����
        //���� ����ġ �ݿ�
        //�ð� �ٽ� üũ 
        AddAccountExp();
        AddUseItem();
        _OnButtonTime = DateTime.Now; // ������� �ð��� üũ //���Ϸ� ����
    }

    void AddAccountExp()
    {
        _accTime = (float)(DateTime.Now - _OnButtonTime).TotalSeconds;
        // �� ���� ����ġ�� ���� ����ġ ����ֱ�
        //�ð��� ���� ����ġ ���� 30�п� 1�� (MAx����ġ ��������, 1�ۺ��� ���ѵ� �־����� ����ġ ���� �ֱ�)
        _neglectExp = ((_accTime / 10)) * _neglectExpMag; //Ȯ���ϱ� ���� �ӽ÷� 10�ʷ� ����
        Debug.Log("����ġ ����" + _neglectExp);
    }
    
    void AddUseItem() // ���������� �ð��� �帧�� ������ �����ؼ� �ִ� �������� �������� �ø� ex) 1������ 10����ġå�ִٰ� 2������ 20����ġ å �ִ� ����
    {

    }

    private void OnDisable()
    {
       
    }
}
