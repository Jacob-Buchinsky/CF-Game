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
        }
        
    }

    public void Remove (Item item)
    {
        items.Remove(item);
    }

    public void Start() {
        foreach (Item ITEM in items) {
            Add(ITEM);
            Debug.Log(ITEM.name);
        }
    }
}
