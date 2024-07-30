using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int count;
        public int maxAllowed;

        public Sprite icon;

        public Slot()
        {
            itemName = "";
            count = 0;
            maxAllowed = 99;
        }

        /// <summary>
        /// Checks if item can be added to the slot.
        /// </summary>
        /// <returns>True if item can be added.</returns>
        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds item to the slot
        /// </summary>
        /// <param name="item">Item to add.</param>
        public void AddItem(Item item)
        {
            this.itemName = item.data.itemName;
            this.icon = item.data.icon;
            count++;
        }

        /// <summary>
        /// Removes item from the slot.
        /// </summary>
        public void RemoveItem()
        {
            if (count > 0)
            {
                count--;

                // Slot becomes empty
                if (count == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }
    }

    public List<Slot> slots = new List<Slot>();

    /// <summary>
    /// Constructs the inventory consisting of slots.
    /// </summary>
    /// <param name="numSlots">Number of slots to add.</param>
    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            slots.Add(new Slot());
        }
    }

    /// <summary>
    /// Adds an item to the inventory.
    /// </summary>
    /// <param name="item">Item to add.</param>
    public void Add(Item item)
    {
        // Add item to existing items
        foreach (Slot slot in slots)
        {
            if (slot.itemName == item.data.itemName && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        // Add item to new slot
        foreach (Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                slot.AddItem(item);
                return;
            }
        }
    }

    /// <summary>
    /// Removes item from the inventory.
    /// </summary>
    /// <param name="index">Index of slot to remove item from.</param>
    public void Remove(int index)
    {
        slots[index].RemoveItem();
    }

    /// <summary>
    /// Removes multiple items.
    /// </summary>
    /// <param name="index">Index of slot to remove item from.</param>
    /// <param name="numToRemove">Number of items to remove.</param>
    public void Remove(int index, int numToRemove)
    {
        if (slots[index].count >= numToRemove)
        {
            for (int i = 0; i < numToRemove; i++)
            {
                Remove(index);
            }
        }
    }
}
