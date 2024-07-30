using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inevntory_UI : MonoBehaviour
{
    public GameObject inventoryPanel;

    public Player player;

    public List<Slot_UI> slots = new List<Slot_UI>();

    [SerializeField] private Canvas canvas;
    private bool dragSingle;

    private Slot_UI draggedSlot;
    private Image draggedIcon;

    private void Awake()
    {
        canvas = FindAnyObjectByType<Canvas>();
    }

    void Update()
    {
        // Open/Close inventory
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }

        // How many items to drag
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dragSingle = true; // Only drag one item
        }
        else
        {
            dragSingle = false;
        }
    }

    /// <summary>
    /// Shows/Hides inventory.
    /// </summary>
    public void ToggleInventory()
    {
        if (!inventoryPanel.activeSelf)
        {
            inventoryPanel.SetActive(true);
            Refresh();
        }
        else
        {
            inventoryPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Refreshes inventory slots.
    /// </summary>
    private void Refresh()
    {
        if (slots.Count == player.inventory.slots.Count)
        {
            for (int i = 0; i < slots.Count; i++)
            {
                if (player.inventory.slots[i].itemName != "")
                {
                    slots[i].SetItem(player.inventory.slots[i]);
                }
                else
                {
                    slots[i].SetEmpty();
                }
            }
        }
    }

    /// <summary>
    /// Removes item from inventory
    /// </summary>
    public void Remove()
    {
        Item itemToDrop = GameManager.Instance.itemManager.GetItemByName(player.inventory.slots[draggedSlot.slotID].itemName);

        if (itemToDrop != null)
        {
            if (dragSingle)
            {
                player.DropItem(itemToDrop);
                player.inventory.Remove(draggedSlot.slotID);
            }
            else
            {
                player.DropItem(itemToDrop, player.inventory.slots[draggedSlot.slotID].count);
                player.inventory.Remove(draggedSlot.slotID, player.inventory.slots[draggedSlot.slotID].count);
            }
            
            Refresh();
        }

        draggedSlot = null;
    }

    /// <summary>
    /// Instantiates icon to mouse (start dragging).
    /// </summary>
    /// <param name="slot">Dragged slot.</param>
    public void SlotBeginDrag(Slot_UI slot)
    {
        draggedSlot = slot;
        // Creates icon
        draggedIcon = Instantiate(draggedSlot.itemIcon);
        draggedIcon.transform.SetParent(canvas.transform);
        draggedIcon.raycastTarget = false; // Does not block slots
        draggedIcon.rectTransform.sizeDelta = new Vector2(50, 50);

        MoveToMousePosition(draggedIcon.gameObject);
    }

    /// <summary>
    /// Move icon to mouse position (dragging).
    /// </summary>
    public void SlotDrag()
    {
        MoveToMousePosition(draggedIcon.gameObject);
    }

    /// <summary>
    /// Clean up.
    /// </summary>
    public void SlotEndDrag()
    {
        Destroy(draggedIcon.gameObject);
        draggedIcon = null;
    }

    /// <summary>
    /// Drop dragged item onto another slot.
    /// </summary>
    /// <param name="slot">Slot item is dropped onto.</param>
    public void SlotDrop(Slot_UI slot)
    {
        Debug.Log("Dropped: " + draggedSlot.name + " on " + slot.name);
    }

    /// <summary>
    /// Moves icon to mouse position.
    /// </summary>
    /// <param name="toMove">Icon to move.</param>
    private void MoveToMousePosition(GameObject toMove)
    {
        if (canvas != null)
        {
            Vector2 position; // Converted mouse position

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);

            toMove.transform.position = canvas.transform.TransformPoint(position);
        }
    }
}
