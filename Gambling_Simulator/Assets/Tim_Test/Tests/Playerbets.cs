using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//betting prototype for craps 
public class CrapsGame : MonoBehaviour
{
    public int playerBalance 100; // placeholder player balance 

    public int placeBet()
    {
        int[] validBets = {5, 10, 25, 50}; 
        int bet = 0; 
        bool isValidbet = false; 
        Debug.Log("Place your bet! Choose, $5, $10, $25, $50.");

        while (!isValidbet)
        {
            string input = getPlayerInput(); // placeholder for input handling
            if (int.TryParse(input, out bet) && System.Array.Exists(validBets, denomination => denomination == bet))
            {
                if (bet <= playerBalance)
                {
                    isValidbet = true; 
                }
                else 
                {
                    Debug.Log($"BROKE! Your Balance is ${playerBalance}. You need money to play! come back later");

                }
            }
        }
        else 
        {
            Debug.Log("Invalid bet amount. Please choose the right amount ($5, $10, $25, or $50)");
        }
    }
    
    playerBalance -= bet;
    Debug.Log($"You put down ${bet}. your new balance is ${playerBalance}.");
    return bet;
}

private string getPlayerInput()
{
    // Placeholder for player input 
    // replace with UI input later 
    return "10"; // testing example 
}
