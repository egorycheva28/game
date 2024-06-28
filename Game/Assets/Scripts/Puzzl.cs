using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzl : MonoBehaviour
{
    public NumberBox boxPrefab;

    [SerializeField] GameObject winPanel;

    [SerializeField] GameObject buttonback;

    public Door door;

    public NumberBox[,] boxes = new NumberBox[4, 4];

    public Sprite[] sprites;

    private bool isSolved = false;

    void Start()
    {
        winPanel.SetActive(false);  // Скрываем панель победы при старте
        Init();
        for (int i = 0; i < 999; i++)
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
            RemoveAllBoxes();
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
    void RemoveAllBoxes()
    {
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y < 4; y++)
            {
                boxes[x, y].gameObject.SetActive(false);
            }
        }
    }
}