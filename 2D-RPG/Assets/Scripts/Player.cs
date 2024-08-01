using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    private TileManager tileManager;

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
        tileManager = GameManager.Instance.tileManager;
    }

    private void Update()
    {
        // Interact with tile.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (tileManager != null)
            {
                Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

                string tileName = tileManager.GetTileName(position);

                if (!string.IsNullOrWhiteSpace(tileName))
                {
                    if (tileName == "Interactable" && inventoryManager.toolbar.selectedSlot.itemName == "Hoe")
                    {
                        tileManager.SetInteracted(position);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Drops item from inventory and spawns it in the world.
    /// </summary>
    /// <param name="item">Item to drop.</param>
    public void DropItem(Item item)
    {
        Vector3 spawnLocation = transform.position;

        Vector3 spawnOffset = Random.insideUnitCircle * 1.25f;

        Item droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

        droppedItem.rb2d.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
    }

    /// <summary>
    /// Drops item from inventory and spawns it in the world.
    /// </summary>
    /// <param name="item">Item to drop.</param>
    /// <param name="numToDrop">Number of items to drop.</param>
    public void DropItem(Item item, int numToDrop)
    {
        for (int i = 0; i < numToDrop; i++)
        {
            DropItem(item);
        }
    }
}
