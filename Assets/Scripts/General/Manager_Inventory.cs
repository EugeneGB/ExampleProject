using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Inventory : MonoBehaviour
{
    #region SINGLETONE
    public static Manager_Inventory instance;
    #endregion

    [Header("References")]
    [SerializeField] GameObject InventoryWindow;

    [Header("Inventory settings")]
    [SerializeField] List<Transform> inventoryCells = new List<Transform>();
    public Cell selectCell(Cell currentCell)
    {
        return currentCell;
    }
    bool isInventoryOpen = false;

    [System.Serializable] public struct Items
    {
        public string name;
        public int id;
        public Sprite sprite;
    }
    [SerializeField] Items[] items;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);


    }
    private void Start()
    {
        InventoryWindow.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();
        }
    }


    private void OpenInventory()
    {
        if (isInventoryOpen == true)
        {
            isInventoryOpen = false;
            InventoryWindow.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (isInventoryOpen == false)
        {
            isInventoryOpen = true;
            InventoryWindow.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}