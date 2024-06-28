//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Puzzle : MonoBehaviour
//{
//    public NumberBox boxPrefab;
//    public NumberBox[,] boxes = new NumberBox[4, 4];
//    public Sprite[] sprites;

//    void Start()
//    {
//        Init();

//    }

//    //void Init()
//    //{
//    //    int n = 0;
//    //    for (int y = 3; y >= 0; y--)
//    //    {
//    //        for (int x = 0; x < 4; x++)
//    //        {
//    //            NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

//    //            // Проверяем, является ли это последней ячейкой
//    //            if (x == 3 && y == 0)
//    //            {
//    //                box.Init(x, y, 16, null, ClickToSwap); // Индекс 16 означает пустую ячейку
//    //            }
//    //            else
//    //            {
//    //                box.Init(x, y, n + 1, n < sprites.Length ? sprites[n] : null, ClickToSwap);
//    //            }

//    //            boxes[x, y] = box;
//    //            n++;
//    //        }
//    //    }
//    //}

//    void Init()
//    {
//        List<int> numbers = new List<int>();
//        for (int i = 1; i <= 15; i++) // 1 через 15, последним будет пустая ячейка (16)
//        {
//            numbers.Add(i);
//        }

//        // Перемешиваем список чисел
//        numbers = ShuffleList(numbers);

//        int n = 0;
//        for (int y = 3; y >= 0; y--)
//        {
//            for (int x = 0; x < 4; x++)
//            {
//                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

//                // Проверяем, является ли это последняя ячейка
//                if (x == 3 && y == 0)
//                {
//                    box.Init(x, y, 16, null, ClickToSwap); // Индекс 16 означает пустую ячейку
//                }
//                else
//                {
//                    box.Init(x, y, numbers[n], n < sprites.Length ? sprites[n] : null, ClickToSwap);
//                    n++;
//                }

//                boxes[x, y] = box;
//            }
//        }
//    }

//    List<int> ShuffleList(List<int> list)
//    {
//        for (int i = list.Count - 1; i > 0; i--)
//        {
//            int j = Random.Range(0, i + 1);
//            // Поменять местами элементы i и j
//            int temp = list[i];
//            list[i] = list[j];
//            list[j] = temp;
//        }
//        return list;
//    }

//    void ClickToSwap(int x, int y)
//    {
//        int dx = getDx(x, y);
//        int dy = getDy(x, y);

//        Swap(x, y, dx, dy);
//    }

//    void Swap(int x, int y, int dx, int dy)
//    {


//        if (dx == 0 && dy == 0)
//        {
//            return; // Ничего не делаем, если нет доступных для обмена ячеек
//        }

//        var from = boxes[x, y];
//        var target = boxes[x + dx, y + dy];
//        // swap this 2 boxes
//        boxes[x, y] = target;
//        boxes[x + dx, y + dy] = from;

//        //update pos 2 boxes
//        from.UpdatePos(x + dx, y + dy);
//        target.UpdatePos(x, y);
//    }

//    int getDx(int x, int y)
//    {
//        // справа пусто?
//        if (x < 3 && boxes[x + 1, y].IsEmpty())
//        {
//            return 1;
//        }
//        // слева пусто?
//        if (x > 0 && boxes[x - 1, y].IsEmpty())
//        {
//            return -1;
//        }
//        return 0;
//    }

//    int getDy(int x, int y)
//    {
//        // сверху пусто?
//        if (y < 3 && boxes[x, y + 1].IsEmpty())
//        {
//            return 1;
//        }
//        // снизу пусто?
//        if (y > 0 && boxes[x, y - 1].IsEmpty())
//        {
//            return -1;
//        }
//        return 0;
//    }

//    //void Shuffle()
//    //{
//    //    for (int i = 0; i < 4; i++)
//    //    {
//    //        for (int j = 0; j < 4; j++)
//    //        {
//    //            if (boxes[i, j].IsEmpty())
//    //            {
//    //                Vector2 pos = getValidMove(i, j);
//    //                Swap(i, j, (int)pos.x, (int)pos.y);
//    //            }
//    //        }
//    //    }
//    //}

//    private Vector2 lastMove;

//    Vector2 getValidMove(int x, int y)
//    {
//        Vector2 pos = new Vector2();
//        int n = Random.Range(0, 4);
//        do
//        {
//            if (n == 0)
//                pos = Vector2.left;
//            else if (n == 1)
//                pos = Vector2.right;
//            else if (n == 2)
//                pos = Vector2.up;
//            else
//                pos = Vector2.down;
//        } while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));

//        lastMove = pos;
//        return pos;
//    }

//    bool isValidRange(int n)
//    {
//        return n >= 0 && n <= 3;
//    }

//    bool isRepeatMove(Vector2 pos)
//    {
//        return pos * -1 == lastMove;
//    }
//}
////////////////////////////////////////////////////////////////////////////////////////////////////////////
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Puzzle : MonoBehaviour
//{
//    public NumberBox boxPrefab;
//    public NumberBox[,] boxes = new NumberBox[4, 4];
//    public Sprite[] sprites;

//    void Start()
//    {
//        Init();
//    }

//    void Init()
//    {
//        List<int> numbers = new List<int>();
//        for (int i = 1; i <= 15; i++) // 1 через 15, последним будет пустая ячейка (16)
//        {
//            numbers.Add(i);
//        }

//        // Перемешиваем список чисел
//        numbers = ShuffleList(numbers);

//        int n = 0;
//        for (int y = 3; y >= 0; y--)
//        {
//            for (int x = 0; x < 4; x++)
//            {
//                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

//                // Проверяем, является ли это последняя ячейка
//                if (x == 3 && y == 0)
//                {
//                    box.Init(x, y, 16, null, ClickToSwap); // Индекс 16 означает пустую ячейку
//                }
//                else
//                {
//                    box.Init(x, y, numbers[n], n < sprites.Length ? sprites[n] : null, ClickToSwap);
//                    n++;
//                }

//                boxes[x, y] = box;
//            }
//        }
//    }

//    List<int> ShuffleList(List<int> list)
//    {
//        for (int i = list.Count - 1; i > 0; i--)
//        {
//            int j = Random.Range(0, i + 1);
//            // Поменять местами элементы i и j
//            int temp = list[i];
//            list[i] = list[j];
//            list[j] = temp;
//        }
//        return list;
//    }

//    void ClickToSwap(int x, int y)
//    {
//        int dx = getDx(x, y);
//        int dy = getDy(x, y);

//        Swap(x, y, dx, dy);
//    }

//    void Swap(int x, int y, int dx, int dy)
//    {
//        if (dx == 0 && dy == 0)
//        {
//            return; // Ничего не делаем, если нет доступных для обмена ячеек
//        }

//        var from = boxes[x, y];
//        var target = boxes[x + dx, y + dy];

//        // Swap these 2 boxes
//        boxes[x, y] = target;
//        boxes[x + dx, y + dy] = from;

//        //update pos 2 boxes
//        from.UpdatePos(x + dx, y + dy);
//        target.UpdatePos(x, y);
//    }

//    int getDx(int x, int y)
//    {
//        // справа пусто?
//        if (x < 3 && boxes[x + 1, y].IsEmpty())
//        {
//            return 1;
//        }
//        // слева пусто?
//        if (x > 0 && boxes[x - 1, y].IsEmpty())
//        {
//            return -1;
//        }
//        return 0;
//    }

//    int getDy(int x, int y)
//    {
//        // сверху пусто?
//        if (y < 3 && boxes[x, y + 1].IsEmpty())
//        {
//            return 1;
//        }
//        // снизу пусто?
//        if (y > 0 && boxes[x, y - 1].IsEmpty())
//        {
//            return -1;
//        }
//        return 0;
//    }
//}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;
    public NumberBox[,] boxes = new NumberBox[4, 4];
    public Sprite[] sprites;

    void Start()
    {
        Init();
    }

    void Init()
    {
        List<int> numbers = new List<int>();
        for (int i = 1; i <= 15; i++) // 1 через 15
        {
            numbers.Add(i);
        }

        // Перемешиваем список чисел
        numbers = ShuffleList(numbers);

        int n = 0;
        for (int y = 3; y >= 0; y--)
        {
            for (int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

                if (n < numbers.Count)
                {
                    box.Init(x, y, numbers[n], n < sprites.Length ? sprites[n] : null, ClickToSwap);
                    n++;
                }
                else
                {
                    box.Init(x, y, 16, null, ClickToSwap); // Положение пустой ячейки
                }

                boxes[x, y] = box;
            }
        }
    }

    //List<int> ShuffleList(List<int> list)
    //{
    //    for (int i = list.Count - 1; i > 0; i--)
    //    {
    //        int j = Random.Range(0, i + 1);
    //        // Поменять местами элементы i и j
    //        int temp = list[i];
    //        list[i] = list[j];
    //        list[j] = temp;
    //    }
    //    return list;
    //}

    List<int> ShuffleList(List<int> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
        return list;
    }


    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        Swap(x, y, dx, dy);
    }

    void Swap(int x, int y, int dx, int dy)
    {
        if (dx == 0 && dy == 0)
        {
            return; // Ничего не делаем, если нет доступных для обмена ячеек
        }

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        // Swap these 2 boxes
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        // update pos 2 boxes
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        // справа пусто?
        if (x < 3 && boxes[x + 1, y].IsEmpty())
        {
            return 1;
        }
        // слева пусто?
        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
        }
        return 0;
    }

    int getDy(int x, int y)
    {
        // сверху пусто?
        if (y < 3 && boxes[x, y + 1].IsEmpty())
        {
            return 1;
        }
        // снизу пусто?
        if (y > 0 && boxes[x, y - 1].IsEmpty())
        {
            return -1;
        }
        return 0;
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;

    [SerializeField] GameObject winPanel;

    [SerializeField] GameObject buttonback;


    public NumberBox[,] boxes = new NumberBox[4, 4];

    public Sprite[] sprites;

    private bool isSolved = false;

    void Start()
    {
        winPanel.SetActive(false);  // Скрываем панель победы при старте
        Init();
        for (int i = 0; i < 2; i++)
        {
            Shuffle();
        }

        Debug.Log(IsPuzzleSolved() ? "Puzzle is solved" : "Puzzle is not solved");
    }

    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
        {
            for (int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);

                box.Init(x, y, n + 1, sprites[n], ClickToSwap);

                boxes[x, y] = box;
                n++;
            }
        }
    }

    void ClickToSwap(int x, int y)
    {
        if (isSolved)
        {
            return;  // Блокируем движение, если головоломка решена
        }

        int dx = getDx(x, y);
        int dy = getDy(x, y);

        Swap(x, y, dx, dy);

        if (IsPuzzleSolved())
        {
            Debug.Log("Puzzle is solved");
            winPanel.SetActive(true);
            buttonback.SetActive(false);
            isSolved = true;  
        }
        else
        {
            Debug.Log("Puzzle is NOT solved");
        }
    }

    void Swap(int x, int y, int dx, int dy)
    {
        if (dx == 0 && dy == 0)
        {
            return;
        }

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];

        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        if (x < 3 && boxes[x + 1, y].IsEmpty())
        {
            return 1;
        }

        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
        }
        return 0;
    }

    int getDy(int x, int y)
    {
        if (y < 3 && boxes[x, y + 1].IsEmpty())
        {
            return 1;
        }

        if (y > 0 && boxes[x, y - 1].IsEmpty())
        {
            return -1;
        }
        return 0;
    }

    void Shuffle()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (boxes[i, j].IsEmpty())
                {
                    Vector2 pos = getValidMove(i, j);
                    Swap(i, j, (int)pos.x, (int)pos.y);
                }
            }
        }
    }

    private Vector2 lastMove;

    Vector2 getValidMove(int x, int y)
    {
        Vector2 pos = new Vector2();

        do
        {
            int n = Random.Range(0, 4);

            if (n == 0)
                pos = Vector2.left;
            else if (n == 1)
                pos = Vector2.right;
            else if (n == 2)
                pos = Vector2.up;
            else
                pos = Vector2.down;
        } while (!(isValidRange(x + (int)pos.x) && isValidRange(y + (int)pos.y)) || isRepeatMove(pos));

        lastMove = pos;
        return pos;
    }

    bool isValidRange(int n)
    {
        return n >= 0 && n <= 3;
    }

    bool isRepeatMove(Vector2 pos)
    {
        return pos * -1 == lastMove;
    }

    bool IsPuzzleSolved()
    {
        int count = 1;
        for (int y = 3; y >= 0; y--)
        {
            for (int x = 0; x < 4; x++)
            {
                if (y == 0 && x == 3)
                {
                    if (!boxes[x, y].IsEmpty())
                    {
                        return false;
                    }
                }
                else
                {
                    if (boxes[x, y].index != count)
                    {
                        return false;
                    }
                    count++;
                }
            }
        }
        return true;
    }
}

