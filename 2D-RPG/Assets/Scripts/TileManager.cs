using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;

    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;

    void Start()
    {
        // Sets up interactable tiles
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);

            if (tile != null && tile.name == "Interactable_Visible")
            {
                interactableMap.SetTile(position, hiddenInteractableTile);
            }
        }
    }

    /// <summary>
    /// Checks if tile is interactable.
    /// </summary>
    /// <param name="position">Position of the tile.</param>
    /// <returns>True if interactable.</returns>
    public bool IsInteractable(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if (tile != null)
        {
            if (tile.name == "Interactable")
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Plowing of interacted tile.
    /// </summary>
    /// <param name="position">Position of tile.</param>
    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }
}
