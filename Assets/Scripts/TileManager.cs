using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];

    private Text swordScoreText;
    private Text shieldScoreText;

    public ButtonPanel buttonPanel;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;
    private bool tie;

    // Start is called before the first frame update
    void Start()
    {
        // Hide Buttons Uniil Round Ends
        buttonPanel.HideResetButton();
        buttonPanel.HideQuitButton();

        won = false;
        tie = false;
        CurrentPlayer = Owner.Sword;

        // Used For Updating Scores of Players
        swordScoreText = GameObject.Find("SwordScore").GetComponent<Text>();
        shieldScoreText = GameObject.Find("ShieldScore").GetComponent<Text>();
    }

    public void Reset()
    {
        for (int i = 0; i < 9; ++i)
        {
            Tiles[i].GetComponent<SpriteRenderer>().color = Color.white; // Reset Back to Default White Color
            Tiles[i].owner = Owner.None; // Assign No Owner
            Tiles[i].tileTaken = false; // Assign that All Tiles are Availiable
            Destroy(Tiles[i].ownerSymbol); // Destoy Tile's Symbol
        }

        buttonPanel.HideResetButton();
        buttonPanel.HideQuitButton();

        won = false;
        tie = false;
        CurrentPlayer = Owner.Sword;

        Debug.Log("Resetting...");
    }

    public void Quit()
    {
        buttonPanel.HideResetButton();
        buttonPanel.HideQuitButton();

        Application.Quit(); // Will Not Work in Editor

        Debug.Log("Quitting...");
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
        {
            // Update Scores Based on Who Wins
            if (CurrentPlayer == Owner.Sword)
            {
                swordScoreText.GetComponent<SwordScoreController>().swordScore += 1;
                swordScoreText.GetComponent<SwordScoreController>().UpdateSwordScore();
            }
            else if (CurrentPlayer == Owner.Shield)
            {
                shieldScoreText.GetComponent<ShieldScoreController>().shieldScore += 1;
                shieldScoreText.GetComponent<ShieldScoreController>().UpdateShieldScore();
            }

            // Lock all tiles, so player cannot keep pressing and earning points when deciding between Reset and Quit
            for (int i = 0; i < 9; ++i)
            {
                Tiles[i].tileTaken = true;
            }

            // Round Over -> Show Reset and Quit
            buttonPanel.ShowResetButton();
            buttonPanel.ShowQuitButton();

            return;
        }

        
        if (CheckForTie())
        {
            // Lock all tiles, so player cannot keep pressing and earning points when deciding between Reset and Quit
            for (int i = 0; i < 9; ++i)
            {
                Tiles[i].tileTaken = true;
            }

            buttonPanel.ShowResetButton();
            buttonPanel.ShowQuitButton();

            return;
        }

        if (CurrentPlayer == Owner.Sword)
        {
            CurrentPlayer = Owner.Shield;
        }
        else
        {
            CurrentPlayer = Owner.Sword;
        }
    }

    
    public bool CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
        {
            won = true;
        }
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
        {
            won = true;
        }

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            return true;
        }

        return false;
    }

    public bool CheckForTie()
    {
       for (int i = 0; i < 9; ++i)
       {
            if (Tiles[i].tileTaken) // If all tiles are taken, then we have a tie
            {
                tie = true;
            }
            else
            {
                tie = false;
                break;
            }
       }

       if (tie)
       {
            Debug.Log("Tie! No Winner or Loser!");
            return true;
       }

       return false;
    }
}
