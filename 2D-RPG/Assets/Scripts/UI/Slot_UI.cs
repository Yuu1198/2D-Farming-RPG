using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;

    [SerializeField] private GameObject highlight;

    /// <summary>
    /// Sets up item in the slot.
    /// </summary>
    /// <param name="slot">Slot to put the item into.</param>
    public void SetItem(Inventory.Slot slot)
    {
        if (slot != null)
        {
            // Show icon
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1, 1, 1, 1);
            quantityText.text = slot.count.ToString();
        }
    }

    /// <summary>
    /// Empties slot.
    /// </summary>
    public void SetEmpty()
    {
        // No icon
        itemIcon.sprite = null;
        itemIcon.color = new Color(1, 1, 1, 0);
        quantityText.text = "";
    }

    /// <summary>
    /// Sets highlight on/off.
    /// </summary>
    /// <param name="isOn"></param>
    public void SetHighlight(bool isOn)
    {
        highlight.SetActive(isOn);
    }
}
