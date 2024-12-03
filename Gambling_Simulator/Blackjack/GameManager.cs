using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

//** I WOULD PROBABLY IMPLEMENT DOUBLE OPTION HERE. CAN CHECK playerScript.handValue TO SEE IF QUALIFIES
//** ALSO NEED TO ACCOUNT FOR WHAT HAPPENS WHEN BALANCE =0. NOT IMPLEMENTED
//** ERROR CHECKING FOR BETS PLACED NEEDS TO BE DONE
//** COULD GIVE MORE DETAILED MESSAGES WHEN roundOver IDK

public class GameManager : MonoBehaviour
{
    //game objects so we can hide/show them
    public Button dealButton;
    public Button hitButton;
    public Button standButton;
    public Button betButton2;
    public InputField betButton;
    public GameObject hideCard;

    //access player dealer scripts. ie needed so we can update playerScript.balance etc
    public PlayerInfo playerScript;
    public PlayerInfo dealerScript;

    //text to update hud
    public Text scoreText;
    public Text dealerScore;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;

    public int secondCard = 0;
    
    int wager = 0; //atm wager is what the player would win. bet*2


    void Start(){
        //on start, create functions for when buttons are clicked
        dealButton.onClick.AddListener(() => dealClicked());
        hitButton.onClick.AddListener(() => hitClicked());
        standButton.onClick.AddListener(() => standClicked());


        //set initial hud on game start
        dealButton.gameObject.SetActive(true);
        betButton.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealerScore.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
   
    }

    private void dealClicked(){ //dealbtn clicked.. STARTING HAND

        Text newBet = betButton.GetComponentInChildren(typeof(Text)) as Text; //gets whatever text is typed into box 
        int bet = int.Parse(newBet.text.ToString()); //converts text into string. **NO ERROR CHECKING HERE NEEDS TO BE DONE, ie bet more than balance, negative value, string,etc**

        playerScript.adjustBalance(-bet); //removes placed bet from playerbalance
        wager += (bet * 2);

        //update ui
        cashText.text = "Balance: $" + playerScript.getBalance().ToString();
        betsText.text = "Bet: $" + bet.ToString();

        //resets round, empties player&dealerhand
        playerScript.resetHand();
        dealerScript.resetHand();   
        GameObject.Find("deck").GetComponent<CardDeck>().Shuffle(); //shuffles deck

        //gives two cards to each player, (function in playerinfo.cs)
        playerScript.startHand();
        dealerScript.startHand();

        //update the hand calculation text
        scoreText.text = "player: " + playerScript.handValue.ToString();
        dealerScore.text = "dealer: " + dealerScript.handValue.ToString();

        //hides the dealers first card (there is a blank card on top of the dealers 1st card that gets toggled on/off)
        hideCard.GetComponent<Renderer>().enabled = true;


        //hides all buttons that shouldnt be pressed mid hand
        //dealerScoreText.gameObject.SetActive(true); //can be enabled for testing, but will show value of hidden dealer card atm
        scoreText.gameObject.SetActive(true);
        mainText.gameObject.SetActive(false);
        dealerScore.gameObject.SetActive(false);
        dealButton.gameObject.SetActive(false);
        betButton.gameObject.SetActive(false);
        betButton2.gameObject.SetActive(false);
        hitButton.gameObject.SetActive(true);
        standButton.gameObject.SetActive(true);
    }

    private void hitClicked(){      
        playerScript.getCard(); //give player new card
        scoreText.text = "player: " + playerScript.handValue.ToString(); //updates text of value
        if (playerScript.handValue > 21) roundOver();//IF PLAYER BUST
        
    }
    
    private void standClicked(){
        hitDealer(); //dealer hits if under 17.
        roundOver(); //will determine who wins
    }

    private void hitDealer()
    {
        while (dealerScript.handValue < 17)
        {
            dealerScript.getCard();        
            dealerScore.text = "dealer: " + dealerScript.handValue.ToString();
        }
    }

   

    void roundOver()
    { 
        //check for busts
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
           
        //***THIS COULD BE CHANGED TO GIVE MORE SPECIFIC MESSAGES*** IE PLAYERBUST,DEALERBUST, RATHER THAN JUST WIN/LOSE ETC,ETC

        //if player busts or if dealer has higher hand. dealer wins
        if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "DEALER WINS";
        }
        //if dealer busts or player has higher hand. player wins
        else if (dealerBust || (!playerBust && playerScript.handValue > dealerScript.handValue))
        {
            mainText.text = "YOU WIN";
            playerScript.adjustBalance(wager);
        }
        //check for tie, return bets
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "PUSH: BETS RETURNED";
            playerScript.adjustBalance(wager / 2);
        }

        // Set ui up for next move / hand / turn 
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealButton.gameObject.SetActive(true);
        betButton.gameObject.SetActive(true);
        betButton2.gameObject.SetActive(true);
        mainText.gameObject.SetActive(true);
        dealerScore.gameObject.SetActive(true);
        hideCard.GetComponent<Renderer>().enabled = false;
        cashText.text = "Balance: $" + playerScript.getBalance().ToString();
        wager = 0;       
    }  
}
