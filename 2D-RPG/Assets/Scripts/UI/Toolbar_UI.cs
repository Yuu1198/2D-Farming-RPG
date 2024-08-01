using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar_UI : MonoBehaviour
{
    [SerializeField] private List<Slot_UI> toolbarSlots = new List<Slot_UI>();

    private Slot_UI selectedSlot;

    private void Start()
    {
        // Select first toolbar slot
        SelectSlot(0);
    }

    private void Update()
    {
        CheckAlphaNumericKeys();
    }

    /// <summary>
    /// Selects slot.
    /// </summary>
    /// <param name="slot">Slot to select.</param>
    public void SelectSlot(Slot_UI slot)
    {
        SelectSlot(slot.slotID);
    }

    /// <summary>
    /// Selects slot based on index.
    /// </summary>
    /// <param name="index">Index of slot to select.</param>
    public void SelectSlot(int index)
    {
        if (toolbarSlots.Count == 10)
        {
            if (selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }

            selectedSlot = toolbarSlots[index];
            selectedSlot.SetHighlight(true);

            GameManager.Instance.player.inventoryManager.toolbar.SelectSlot(index);
        }
    }

    /// <summary>
    /// Selects slot based on input.
    /// </summary>
    private void CheckAlphaNumericKeys()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            SelectSlot(3);
        }

        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            SelectSlot(4);
        }

        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            SelectSlot(5);
        }

        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            SelectSlot(6);
        }

        if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            SelectSlot(7);
        }

        if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            SelectSlot(8);
        }

        if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            SelectSlot(9);
        }
    }
}
