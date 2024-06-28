using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement;//���-�� ���� ��������� �����
    public static int myElement;//����� ���������, ������� �� ����� �����
    public GameObject myPuzzl;//������������ ������, ���������� ��� �������� ����� 
    public GameObject myPanel;//������ � ������
    public GameObject winPanel;//������ ������
    public GameObject arrow;

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;//�������� ���-�� ��������� �����
    }

    
    void Update()
    {
        if(fullElement==myElement)//���� ��� �������� �� ����� �����
        {
            myPanel.SetActive(false);//�������� ������ � ������
            winPanel.SetActive(true);//���������� ������ ������
            arrow.SetActive(true);
        }
    }

    //������� ���������� ���-�� ���������, ������� ����� �� ����� �����
    public static void AddElement()
    {
        myElement++;//�����������
    }
}
