using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class Puzzle : MonoBehaviour
{
    public NumberBox boxPrefab;

    public NumberBox[,] boxes = new NumberBox[4,4];

    public Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Init()
    {
        int n = 0;
        for (int y = 3; y >= 0; y--)
            for (int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, sprites[n], ClickToSwap);
                boxes[x, y] = box;
                n++;
            }

    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];
        // swap this 2 boxes
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //update pos 2 boxes
        from.UpdatePos(x + dx, y + dy);
        target.UpdatePos(x, y);
    }

    int getDx(int x, int y)
    {
        // is right empty
        if (x < 3 && boxes[x+1, y].IsEmpty())
        {
            return 1;
        }
        // is left empty
        if (x > 0 && boxes[x - 1, y].IsEmpty())
        {
            return -1;
        }
        return 0;
    }

    int getDy(int x, int y)
    {
        // is top empty
        if (y < 3 && boxes[x, y+1].IsEmpty())
        {
            return 1;
        }
        // is bottom empty
        if (y> 0 && boxes[x, y-1].IsEmpty())
        {
            return -1;
        }
        return 0;
    }
}
*/

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
        int n = 0;
        for (int y = 3; y >= 0; y--)
        {
            for (int x = 0; x < 4; x++)
            {
                NumberBox box = Instantiate(boxPrefab, new Vector2(x, y), Quaternion.identity);
                box.Init(x, y, n + 1, n < sprites.Length ? sprites[n] : null, ClickToSwap);
                boxes[x, y] = box;
                n++;
            }
        }
        // Установим одну из ячеек явно пустой
        boxes[3, 0].Init(3, 0, 16, null, ClickToSwap); // Последняя ячейка пустая
    }

    void ClickToSwap(int x, int y)
    {
        int dx = getDx(x, y);
        int dy = getDy(x, y);

        if (dx == 0 && dy == 0)
        {
            return; // Ничего не делаем, если нет доступных для обмена ячеек
        }

        var from = boxes[x, y];
        var target = boxes[x + dx, y + dy];
        // swap this 2 boxes
        boxes[x, y] = target;
        boxes[x + dx, y + dy] = from;

        //update pos 2 boxes
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
}
