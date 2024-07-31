using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public Dictionary<string, Inevntory_UI> inventoryUIByName = new Dictionary<string, Inevntory_UI>();

    public GameObject inventoryPanel;

    public List<Inevntory_UI> inventoryUIs;

    public static Slot_UI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;

    private void Awake()
    {
        Initialize();
    }

    private void Update()
    {
        // How many items to drag
        if(Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true; // Only drag one item
        }
        else
        {
            dragSingle = false;
        }

        // Open/Close inventory
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventoryUI();
        }
    }

    /// <summary>
    /// Shows/Hides inventory.
    /// </summary>
    public void ToggleInventoryUI()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Refreshes an inventory.
    /// </summary>
    /// <param name="inventoryName">Inventory to refresh.</param>
    public void RefreshInventoryUI(string inventoryName)
    {
        if(inventoryUIByName.ContainsKey(inventoryName))
        {
            inventoryUIByName[inventoryName].Refresh();
        }
    }

    /// <summary>
    /// Refreshes all of the UI.
    /// </summary>
    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inevntory_UI> keyValuePair in inventoryUIByName)
        {
            keyValuePair.Value.Refresh();
        }
    }

    /// <summary>
    /// Get inventory by name.
    /// </summary>
    /// <param name="inventoryName">Name of the inventory.</param>
    /// <returns></returns>
    public Inevntory_UI GetInventoryUI(string inventoryName)
    {
        if(inventoryUIByName.ContainsKey(inventoryName))
        {
            return inventoryUIByName[inventoryName];
        }

        Debug.Log("There is no inventory UI for" + inventoryName);
        return null;
    }

    /// <summary>
    /// Fills Dictionary.
    /// </summary>
    private void Initialize()
    {
        foreach (Inevntory_UI ui in inventoryUIs)
        {
            if (!inventoryUIByName.ContainsKey(ui.inventoryName))
            {
                inventoryUIByName.Add(ui.inventoryName, ui);
            }
        }
    }
}
