using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrapsGame
{
    public class PlayerBalanceManager : MonoBehaviour
    {
        private int balance = 2000; // Player's default balance
        public ROLL rollScript; // Reference to the ROLL script for input
        private Craps crapsGame; // Reference to the Craps game


        public void Initialize(ROLL rollScript)
        {
            this.rollScript = rollScript;
            crapsGame = new Craps(rollScript); // Initialize the Craps game
        }

        public void StartGame()
        {
            Debug.Log($"Welcome to Craps! Your starting balance is ${balance}.");

            while (balance > 0)
            {
                // Place a bet
                int bet = PlaceBet();

                // Play a single round of Craps
                crapsGame.PlayGame();

                // Update balance based on game outcome
                UpdateBalance(bet, crapsGame.GameStatus == Craps.GameStatus.WIN);

                // Check if the player wants to continue
                if (!AskToContinue())
                {
                    Debug.Log($"You are leaving the game with a balance of ${balance}. Thanks for playing!");
                    break;
                }
            }

            if (balance <= 0)
            {
                Debug.Log("You are out of money! Game over.");
            }
        }

        private int PlaceBet()
        {
            int[] validBets = { 5, 10, 25, 50 };
            int bet = 0;
            bool isValidBet = false;

            while (!isValidBet)
            {
                string input = rollScript.GetPlayerInput("Place your bet! Choose $5, $10, $25, or $50.");
                if (int.TryParse(input, out bet) && System.Array.Exists(validBets, denomination => denomination == bet))
                {
                    if (bet <= balance)
                    {
                        isValidBet = true;
                    }
                    else
                    {
                        Debug.Log($"Insufficient balance! Your current balance is ${balance}. Please try again.");
                    }
                }
                else
                {
                    Debug.Log("Invalid bet amount. Please choose $5, $10, $25, or $50.");
                }
            }

            balance -= bet;
            Debug.Log($"You placed a bet of ${bet}. Your new balance is ${balance}.");
            return bet;
        }

        private void UpdateBalance(int bet, bool isWin)
        {
            if (isWin)
            {
                balance += bet * 2; // Payout is 1:1 on the bet
                Debug.Log($"You won! Your new balance is ${balance}.");
            }
            else
            {
                Debug.Log($"You lost. Your balance remains at ${balance}.");
            }
        }

        private bool AskToContinue()
        {
            string input = rollScript.GetPlayerInput("Do you want to play another round? (Y/N)");
            return input.ToUpper() == "Y";
        }
    }
}