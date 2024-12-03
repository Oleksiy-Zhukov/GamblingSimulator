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
    public Button insuranceButton;
    public Button doubleButton;
    public Button splitButton;
    public Button escapeButton;
    public Button helpButton;
    public Button resetButton;
    public GameObject helpScreen;
    public GameObject insuranceSign;
    public Button exitButton;


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
    int currentBet = 0; //the players current bet to use for side pots
    int insuranceWager = 0; //Wager to use for insurance bet
    int splitWager = 0; //Wager to use for split

    void Start(){
        //on start, create functions for when buttons are clicked
        dealButton.onClick.AddListener(() => dealClicked());
        hitButton.onClick.AddListener(() => hitClicked());
        standButton.onClick.AddListener(() => standClicked());
        doubleButton.onClick.AddListener(() => doubleClicked());
        splitButton.onClick.AddListener(() => splitClicked());
        insuranceButton.onClick.AddListener(() => insuranceClicked());
        resetButton.onClick.AddListener(() => resetClicked());
        helpButton.onClick.AddListener(() => helpClicked());
        escapeButton.onClick.AddListener(() => escapeClicked());

        //set initial hud on game start
        dealButton.gameObject.SetActive(true);
        betButton.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealerScore.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
        insuranceButton.gameObject.SetActive(false);
        splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(true);
        helpScreen.gameObject.SetActive(false);
        insuranceSign.gameObject.SetActive(false);
   
    }

    private void dealClicked(){ //dealbtn clicked.. STARTING HAND


        Text newBet = betButton.GetComponentInChildren(typeof(Text)) as Text; //gets whatever text is typed into box 
        //Error Handling for if their is no bet entered
        if(!newBet){ 
            mainText.text = "Please Enter a Valid Bet";
        }
        int bet = int.Parse(newBet.text.ToString()); //converts text into string. **NO ERROR CHECKING HERE NEEDS TO BE DONE, ie bet more than balance, negative value, string,etc**
        currentBet = bet;

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
        //hides the dealers first card (there is a blank card on top of the dealers 1st card that gets toggled on/off)
        hideCard.GetComponent<Renderer>().enabled = true;
        playerScript.startHand();
        dealerScript.startHand();

        //update the hand calculation text
        scoreText.text = "player: " + playerScript.handValue.ToString();
        dealerScore.text = "dealer: " + dealerScript.handValue.ToString();

        //adding player blackjack win
        if(playerScript.handValue == 21){
            playerBlackjack();
        }


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
        //checking dealers hand to see if insurance is available
        if(dealerScript.card1Ace == true){
            insuranceButton.gameObject.SetActive(true); 
        }
        else{
            insuranceButton.gameObject.SetActive(false);
        }
        //Checking Players Hand to see if split/double are available
        //if(){
            //splitButton.gameObject.SetActive(true);
        //}
        //else{
            splitButton.gameObject.SetActive(false);
        //}
        if(playerScript.handValue >= 9 && playerScript.handValue <= 11){
            doubleButton.gameObject.SetActive(true);
        }
        else{
            doubleButton.gameObject.SetActive(false);
       }
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

    private void playerBlackjack(){
        roundOver();
    }

    private void hitDealer()
    {
        while (dealerScript.handValue < 17)
        {
            dealerScript.getCard();        
            dealerScore.text = "dealer: " + dealerScript.handValue.ToString();
        }
    }

    private void insuranceClicked(){
        playerScript.adjustBalance(-(currentBet/2)); //removes placed bet from playerbalance
        insuranceWager = currentBet;
        insuranceSign.gameObject.SetActive(true);
    }

    private void splitClicked(){

    }
   
    private void doubleClicked(){
        //doubling players bet
        playerScript.adjustBalance(-currentBet); //removes placed bet from playerbalance
        wager = wager + (currentBet * 2); //doubles potential winnings

        //Gives player another card, then ends the round
        playerScript.getCard();
        scoreText.text = "player: " + playerScript.handValue.ToString(); //updates text of value
        if (playerScript.handValue > 21) roundOver();//IF PLAYER BUST
        hitDealer();
        roundOver();
    }

    private void resetClicked(){
        //resets round, empties player&dealerhand
        playerScript.resetHand();
        dealerScript.resetHand();   
        GameObject.Find("deck").GetComponent<CardDeck>().Shuffle(); //shuffles deck

        //set initial hud on game start
        dealButton.gameObject.SetActive(true);
        betButton.gameObject.SetActive(true);
        betButton2.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealerScore.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
        insuranceButton.gameObject.SetActive(false);
        splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(true);
        helpScreen.gameObject.SetActive(false);
        insuranceSign.gameObject.SetActive(false);
    }

    private void helpClicked(){
        helpScreen.gameObject.SetActive(true);

    }

    private void escapeClicked(){
        helpScreen.gameObject.SetActive(false);
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
            //Checking if Insurance bet paysout
            if(dealerScript.handValue == 21 && insuranceWager > 0){
                playerScript.adjustBalance(insuranceWager);
                mainText.text = "DEALER WINS, INSURANCE PAYED OUT";
            }
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
        dealButton.gameObject.SetActive(false);
        betButton.gameObject.SetActive(false);
        betButton2.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
        dealerScore.gameObject.SetActive(true);
        insuranceButton.gameObject.SetActive(false);
        splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        insuranceSign.gameObject.SetActive(false);
        hideCard.GetComponent<Renderer>().enabled = false;
        cashText.text = "Balance: $" + playerScript.getBalance().ToString();
        wager = 0;
        insuranceWager = 0;
        splitWager = 0;       
    }  
}
