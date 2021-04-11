using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;
    public bool tileTaken = false;

    public GameObject swordSprite;
    public GameObject shieldSprite;
    public GameObject ownerSymbol;

    private void OnMouseUp()
    {
        if (tileTaken == true) // Checks if Tile Already Has An Owner Before Assigning Owner's Selection
        {
            return;
        }
        else
        {
            owner = tileManager.CurrentPlayer;
            tileTaken = true;
        }

        if (owner == TileManager.Owner.Sword)
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue; // Change Tile's Color to Match Owner
            ownerSymbol = Instantiate(swordSprite, transform.position, transform.rotation); // Add Tile's Symbol to Match Owner
        }
        else if (owner == TileManager.Owner.Shield)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red; // Change Tile's Color to Match Owner
            ownerSymbol = Instantiate(shieldSprite, transform.position, transform.rotation); // Add Tile's Symbol to Match Owner
        }

        tileManager.ChangePlayer();
    }
}
