using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptCopy : MonoBehaviour
{
    int fullElement;//���-�� ���� ��������� �����
    public static int myElement;//����� ���������, ������� �� ����� �����
    public GameObject myPuzzl;//������������ ������, ���������� ��� �������� ����� 
    public GameObject myPanel;//������ � ������
  
    //public GameObject arrow;

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;//�������� ���-�� ��������� �����
        myElement = 0;
    }


    void Update()
    {
        if (myElement == 7)//���� ��� �������� �� ����� �����
        {
            myPanel.SetActive(false);//�������� ������ � ������
        
            StaticData.canTakeFlower2 = true;
            //arrow.SetActive(true);
        }
        else
        {
            StaticData.canTakeFlower1 = false;
        }
    }

    //������� ���������� ���-�� ���������, ������� ����� �� ����� �����
    public static void AddElement()
    {
        myElement++;//�����������
    }
}