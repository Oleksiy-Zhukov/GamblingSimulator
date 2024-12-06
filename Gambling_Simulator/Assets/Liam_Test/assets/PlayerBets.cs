using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CrapsGame
{
    public class PlayerBets : MonoBehaviour
    {   


        private int balance = 2000; // Player's default balance
        public getBetAmounts bet;

        


        int amount=0;

        public bool victory;
    
        


        void hateUnity()
        {
            Debug.Log($"Welcome to Craps! Your starting balance is ${balance}.");
            


                bet.fart();

                Debug.Log($"the buttons have spawned");

            
                    
              
                
            /*
                crapsGame.PlayGame();
                
                Debug.Log($"crapsgame called");

                if(crapsGame.gameStatus==0){
                    victory=true;
                }else{
                    victory=false;
                }

                UpdateBalance(amount, victory);*/

            

            if (balance <= 0)
            {
                Debug.Log("You are out of money! Game over.");
                bet.quit();
            }
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
        
    }
    
}