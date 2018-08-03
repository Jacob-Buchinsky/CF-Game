using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more than one instance of inventory");
            return;
        }
        instance = this;
    }

    #endregion
    public InventoryUI UI;

    public int space = 12;

    public List<Item> items = new List<Item>();

    public void Add(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(items.Count >= space)
            {
                Debug.Log("Not Enough Room");
                return;
            }
            items.Add(item);
            Debug.Log("Item ADDED");
            UI.UpdateUI();
        }
        
    }

    public void Remove (Item item)
    {
        Debug.Log("REMOVING ITEM FROM LIST: " + item);
        items.Remove(item);
        UI.UpdateUI();
    }

    public void Start() {
        foreach (Item ITEM in items) {
            Debug.Log(ITEM + " In Inventory");
        }
        Debug.Log("YOU BETTER WORK");
        UI.FixUIBug();
        UI.UpdateUI();
    }
}
