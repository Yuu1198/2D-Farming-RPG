using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    /// <summary>
    /// Collects item when player collides with it.
    /// </summary>
    /// <param name="collision">Collider of item.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null )
        {
            Item item = GetComponent<Item>();

            if (item != null)
            {
                player.inventory.Add(item);
                Destroy(this.gameObject);
            }
        }
    }
}
