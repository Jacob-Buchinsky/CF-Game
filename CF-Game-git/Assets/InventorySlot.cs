using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public static Sprite icon2;

    public Item item;

    public void AddItem (Item newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;


    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if (item != null)
        {
            icon2 = item.GetIcon();
            Debug.Log("icon 2: " + icon2);
            item.Use();
        }
        
    }
    /*public Image GetIcon(Item newItem)
    {
        item = newItem;
        return item.icon;
    }*/
}
