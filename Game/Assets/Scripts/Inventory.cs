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
} 