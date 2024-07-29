using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Item[] items;

    private Dictionary<string, Item> nameToItemDict = new Dictionary<string, Item>();

    private void Awake()
    {
        // Adds all existing items to the dictionary.
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }

    /// <summary>
    /// Adds new item to the dictionary
    /// </summary>
    /// <param name="item">Item to add.</param>
    private void AddItem(Item item)
    {
        if (!nameToItemDict.ContainsKey(item.data.itemName))
        {
            nameToItemDict.Add(item.data.itemName, item);
        }
    }

    /// <summary>
    /// Gets item by name from the dictionary
    /// </summary>
    /// <param name="key">Name of the item.</param>
    /// <returns>Item.</returns>
    public Item GetItemByName(string key)
    {
        if (nameToItemDict.ContainsKey(key))
        {
            return nameToItemDict[key];
        }

        return null;
    }
}
