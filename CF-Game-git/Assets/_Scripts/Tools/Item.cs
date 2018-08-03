
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("using" + name);
    }

    public virtual Sprite GetIcon()
    {
        return icon;
    }

    public void RemoveFromInventory()
    {
        Debug.Log("removing from inventory");
        Inventory.instance.Remove(this);
    }
}
