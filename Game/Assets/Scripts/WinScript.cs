using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement;//���-�� ���� ��������� �����
    public static int myElement;//����� ���������, ������� �� ����� �����
    public GameObject myPuzzl;//������������ ������, ���������� ��� �������� ����� 
    public GameObject myPanel;//������ � ������
   
 

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;//�������� ���-�� ��������� �����
    }


    void Update()
    {
        if (fullElement == myElement)//���� ��� �������� �� ����� �����
        {
            myPanel.SetActive(false);//�������� ������ � ������
       
    
        }
    }

    //������� ���������� ���-�� ���������, ������� ����� �� ����� �����
    public static void AddElement()
    {
        myElement++;//�����������
    }
}
