using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    int fullElement;//Кол-во всех элементов пазла
    public static int myElement;//Число элементов, лежащих на своем месте
    public GameObject myPuzzl;//Родительский объект, содержащий все элементы пазла 
    public GameObject myPanel;//Панель с пазлом
   
 

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;//Получаем кол-во элементов пазла
    }


    void Update()
    {
        if (fullElement == myElement)//Если все элементы на своем месте
        {
            myPanel.SetActive(false);//Скрываем панель с пазлом
       
    
        }
    }

    //Функция увеличения кол-ва элементов, которые лежат на своем месте
    public static void AddElement()
    {
        myElement++;//Увеличиваем
    }
}
