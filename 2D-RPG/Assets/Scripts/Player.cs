using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventory;

    private void Awake()
    {
        inventory = GetComponent<InventoryManager>();
    }

    private void Update()
    {
        // Interact with tile.
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x, (int)transform.position.y, 0);

            if (GameManager.Instance.tileManager.IsInteractable(position))
            {
                GameManager.Instance.tileManager.SetInteracted(position);
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
