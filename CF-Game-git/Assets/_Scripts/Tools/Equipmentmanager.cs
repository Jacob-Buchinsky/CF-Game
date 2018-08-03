using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton
    public static EquipmentManager instance;

    void Awake()
    {
        inventory = Inventory.instance;
        Debug.Log("WAKE UP FOOL");
        instance = this;
        Debug.Log("SLOTS PLEASE WORK");
        int numslots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Gear[numslots];
    }
    #endregion

    Gear[] currentEquipment;

    public delegate void OnEquipmentChanged(Gear newItem, Gear oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    Gear oldItem = null;

    void start()
    {
        inventory = Inventory.instance;
        Debug.Log("SLOTS PLEASE WORK");
        int numslots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Gear[numslots];
    }

    public void Equip(Gear newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Gear oldItem = null;
        //Gear oldItem = new Gear();
        Debug.Log("Equipping");
        /* if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            Debug.Log("oldItem = " + oldItem);
            if (oldItem != null)
            {
                inventory.Add(oldItem);
            }
            
        }

        if (onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        */
        currentEquipment[slotIndex] = newItem;
        switch (slotIndex)
        {
            case 0:
                //Image image = InventorySlot.GetIcon(newItem);
                GameObject ChassisImage = GameObject.Find("Chassis Image");
                ChassisImage.GetComponent<Image>().sprite = InventorySlot.icon2;
                Debug.Log("Appearing in armory: " + ChassisImage.GetComponent<Image>().sprite);
                Debug.Log("CHASSIS EQUIPPED");
                break;
            case 1:
                GameObject PowerSupplyImage = GameObject.Find("Power Supply Image");
                PowerSupplyImage.GetComponent<Image>().sprite = InventorySlot.icon2;
                Debug.Log("Appearing in armory: " + PowerSupplyImage.GetComponent<Image>().sprite);
                Debug.Log("Power Supply EQUIPPED");
                break;
            case 2:
                GameObject LegsImage = GameObject.Find("Legs Image");
                LegsImage.GetComponent<Image>().sprite = InventorySlot.icon2;
                Debug.Log("Appearing in armory: " + LegsImage.GetComponent<Image>().sprite);
                Debug.Log("Legs EQUIPPED");
                break;
            case 3:
                GameObject WeaponImage = GameObject.Find("Weapon Image");
                Debug.Log(InventorySlot.icon2);
                WeaponImage.GetComponent<Image>().sprite = InventorySlot.icon2;
                Debug.Log("Appearing in armory: " + WeaponImage.GetComponent<Image>().sprite);
                Debug.Log("Weapon EQUIPPED");
                break;
            case 4:
                GameObject ConsumableImage = GameObject.Find("Consumable Image");
                Debug.Log(InventorySlot.icon2);
                ConsumableImage.GetComponent<Image>().sprite = InventorySlot.icon2;
                Debug.Log("Appearing in armory: " + ConsumableImage.GetComponent<Image>().sprite);
                Debug.Log("Consumable EQUIPPED");
                break;

        }
    }

    public void Unequip(int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Gear oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}

