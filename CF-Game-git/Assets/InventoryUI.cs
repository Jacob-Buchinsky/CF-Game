
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;
    public Transform Inv;

    Inventory inventory;

    InventorySlot[] slots;
	// Use this for initialization
	public void FixUIBug () {
        inventory = Inventory.instance;
       // inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        foreach (InventorySlot Slot in slots)
        {
       //     Debug.Log(slots);
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Toggling Armory");
            if (Inv.gameObject.activeInHierarchy == false)
            {
                Inv.gameObject.SetActive(true);
            }
            else
            {
                Inv.gameObject.SetActive(false);
            }
        }
    }

   public void UpdateUI()
    {
        Debug.Log("updating ui");
        Debug.Log("EAT ASS" + slots.Length);
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Checking slots");
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
                Debug.Log("Adding Element to UI slot");
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

    }
}
