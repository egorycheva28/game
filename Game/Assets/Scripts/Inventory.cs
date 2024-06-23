//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    List<Item> item;
//    public GameObject cellContainer;
//    public KeyCode showInventory;

//    // Start is called before the first frame update
//    void Start()
//    {
//        item = new List<Item>();

//        cellContainer.SetActive(false);

//        for (int i = 0; i < cellContainer.transform.childCount; i++)
//        {
//            item.Add(new Item());
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(showInventory))
//        {
//            if (cellContainer.activeSelf)
//            {
//                cellContainer.SetActive(false);
//            }
//            else
//            {
//                cellContainer.SetActive(true);
//            }
//        }
//    }
//}
/*
using System.Collections;
using System.Collections.Generic;
//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items; 
    public GameObject cellContainer;
    public KeyCode showInventory;
    public KeyCode takeButton;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();

        if (cellContainer != null)
        {
            cellContainer.SetActive(false);

            for (int i = 0; i < cellContainer.transform.childCount; i++)
            {
                items.Add(new Item());
            }
        }
        else
        {
            Debug.LogWarning("CellContainer не присвоен!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TogleInventory();

        if (Input.GetKeyDown(takeButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].id == 0)
                        {
                            items[i] = hit.collider.GetComponent<Item>();
                            DisplayItems();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            break;
                        }
                    }
                }
            }
        }
    }


    void TogleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer != null)
            {
                cellContainer.SetActive(!cellContainer.activeSelf);
            }
            else
            {
                Debug.LogWarning("CellContainer не присвоен!");
            }
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (items[i].id != 0)
            {
                img.enabled = true; 
                img.sprite = Resources.Load<Sprite>(items[i].pathIcon);
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
} */




/*
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private List<Item> items;
    public GameObject cellContainer;
    public KeyCode showInventory = KeyCode.I;
    public KeyCode takeButton = KeyCode.E;

    void Start()
    {
        items = new List<Item>();

        if (cellContainer == null)
        {
            Debug.LogWarning("CellContainer не присвоен!");
            return;
        }

        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            items.Add(gameObject.AddComponent<Item>());
        }
    }

    void Update()
    {
        ToggleInventory();

        if (Input.GetKeyDown(takeButton))
        {
            TryPickUpItem();
        }
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer == null)
            {
                Debug.LogWarning("CellContainer не присвоен!");
                return;
            }

            cellContainer.SetActive(!cellContainer.activeSelf);
        }
    }

    void TryPickUpItem()
    {
        if (Camera.main == null)
        {
            Debug.LogWarning("Main Camera не найдена!");
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit hit, 2f))
        {
            Item item = hit.collider.GetComponent<Item>();
            if (item != null)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].id == 0)
                    {
                        items[i] = item;
                        DisplayItems();
                        Destroy(hit.collider.gameObject);
                        break;
                    }
                }
            }
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            if (cell.childCount > 0)
            {
                Transform icon = cell.GetChild(0);
                Image img = icon.GetComponent<Image>();
                if (img != null)
                {
                    if (items[i].id != 0)
                    {
                        img.enabled = true;
                        img.sprite = Resources.Load<Sprite>(items[i].pathIcon);
                    }
                    else
                    {
                        img.enabled = false;
                        img.sprite = null;
                    }
                }
            }
        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    List<Item> item;
    public int Range;
    public GameObject cellContainer;
    public KeyCode showInventory;

    // Use this for initialization
    void Start()
    {
        item = new List<Item>();

        cellContainer.SetActive(false);

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(gameObject.AddComponent<Item>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Нажата клавиша F");
            Vector3 DirectionRay = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            Debug.DrawRay(transform.position, DirectionRay * Range, Color.red, 2f);
            if (Physics.Raycast(transform.position, DirectionRay, out hit, Range))
            {
                Debug.Log("Объект в зоне досягаемости: " + hit.collider.gameObject.name);
                Item itemComponent = hit.collider.GetComponent<Item>();
                if (itemComponent != null)
                {
                    Debug.Log("Объект является предметом, его ID: " + itemComponent.id);
                    bool itemPickedUp = false;
                    for (int i = 0; i < item.Count; i++)
                    {
                        if (item[i].id == 0)
                        {
                            item[i] = itemComponent;
                            DisplayItems();
                            Destroy(hit.collider.GetComponent<Item>().gameObject);
                            Debug.Log("Предмет подобран и добавлен в инвентарь");
                            itemPickedUp = true;
                            break;
                        }
                    }
                    if (!itemPickedUp)
                    {
                        Debug.Log("Нет свободных слотов в инвентаре для подбора предмета");
                    }
                }
                else
                {
                    Debug.Log("Объект не является предметом");
                }
            }
            else
            {
                Debug.Log("Ничего не найдено в зоне досягаемости");
            }
        }
    }

    void ToggleInventory()
    {
        if (Input.GetKeyDown(showInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
            }
            else
            {
                cellContainer.SetActive(true);
            }
        }
    }

    void DisplayItems()
    {
        for (int i = 0; i < item.Count; i++)
        {
            Transform cell = cellContainer.transform.GetChild(i);
            Transform icon = cell.GetChild(0);
            Image img = icon.GetComponent<Image>();
            if (item[i].id != 0)
            {
                img.enabled = true;
                img.sprite = Resources.Load<Sprite>(item[i].pathIcon);
            }
            else
            {
                img.enabled = false;
                img.sprite = null;
            }
        }
    }
}