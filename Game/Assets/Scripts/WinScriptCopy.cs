using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScriptCopy : MonoBehaviour
{
    int fullElement;//Кол-во всех элементов пазла
    public static int myElement;//Число элементов, лежащих на своем месте
    public GameObject myPuzzl;//Родительский объект, содержащий все элементы пазла 
    public GameObject myPanel;//Панель с пазлом
    public GameObject winPanel;//Панель победы
    //public GameObject arrow;

    void Start()
    {
        fullElement = myPuzzl.transform.childCount;//Получаем кол-во элементов пазла
        myElement = 0;
    }


    void Update()
    {
        if (myElement == 7)//Если все элементы на своем месте
        {
            myPanel.SetActive(false);//Скрываем панель с пазлом
            winPanel.SetActive(true);//Показываем панель победы
            StaticData.canTakeFlower1 = true;
            //arrow.SetActive(true);
        }
        else
        {
            StaticData.canTakeFlower1 = false;
        }
    }

    //Функция увеличения кол-ва элементов, которые лежат на своем месте
    public static void AddElement()
    {
        myElement++;//Увеличиваем
    }
}