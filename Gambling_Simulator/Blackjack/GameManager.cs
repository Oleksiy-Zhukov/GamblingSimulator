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
    //public Button splitButton;
    public Button escapeButton;
    public Button helpButton;
    public Button resetButton;
    public GameObject helpScreen;
    public GameObject insuranceSign;
    public Button exitButton;
    //public Button hand1Hit;
    //public Button hand2Hit;
    //public Button hand1Stand;
    //public Button hand2Stand;


    //access player dealer scripts. ie needed so we can update playerScript.balance etc
    public PlayerInfo playerScript;
    public PlayerInfo dealerScript;
    //adding a script for a split hand
    //public PlayerInfo splitScript1;
    //public PlayerInfo splitScript2;

    //text to update hud
    public Text scoreText;
    public Text dealerScore;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;
    //public Text splitScore1Text;
   //public Text splitScore2Text;
    public Text errorText;
    

    

    public int secondCard = 0;
    
    int wager = 0; //atm wager is what the player would win. bet*2
    int currentBet = 0; //the players current bet to use for side pots
    int insuranceWager = 0; //Wager to use for insurance bet
    int splitWager = 0; //Wager to use for split
    bool insuranceCheck = false; //Checking if insurance has been clicked
    //bool splitCheck = false; //Checking if split has been clicked
    //bool splitHand1Stand = false; //Checking if hand 1 after split has clicked stand
    //bool splitHand2Stand = false; //Checking if hand 2 after split has clicked stand

    void Start(){
        //on start, create functions for when buttons are clicked
        dealButton.onClick.AddListener(() => dealClicked());
        hitButton.onClick.AddListener(() => hitClicked());
        standButton.onClick.AddListener(() => standClicked());
        doubleButton.onClick.AddListener(() => doubleClicked());
        //splitButton.onClick.AddListener(() => splitClicked());
        insuranceButton.onClick.AddListener(() => insuranceClicked());
        resetButton.onClick.AddListener(() => resetClicked());
        helpButton.onClick.AddListener(() => helpClicked());
        escapeButton.onClick.AddListener(() => escapeClicked());
        //hand1Hit.onClick.AddListener(() => hand1HitClicked());
        //hand1Stand.onClick.AddListener(() => hand1StandClicked());
        //hand2Hit.onClick.AddListener(() => hand2HitClicked());
        //hand2Stand.onClick.AddListener(() => hand2StandClicked());
        exitButton.onClick.AddListener(() => exitClicked());

        //set initial hud on game start
        dealButton.gameObject.SetActive(true);
        betButton.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        dealerScore.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
        insuranceButton.gameObject.SetActive(false);
        //splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(true);
        helpScreen.gameObject.SetActive(false);
        insuranceSign.gameObject.SetActive(false);
        //hand1Hit.gameObject.SetActive(false);
        //hand1Stand.gameObject.SetActive(false);
        //hand2Hit.gameObject.SetActive(false);
        //hand2Stand.gameObject.SetActive(false);
        //splitScore1Text.gameObject.SetActive(false);
        //splitScore2Text.gameObject.SetActive(false);
        errorText.gameObject.SetActive(false);
        
   
    }

    private void dealClicked(){ //dealbtn clicked.. STARTING HAND

        
        Text newBet = betButton.GetComponentInChildren(typeof(Text)) as Text; //gets whatever text is typed into box 
        string betString = newBet.text.ToString();
        //Error handling for if the haven't put anything in the bet box
        if(betString.Length < 1){
            mainText.gameObject.SetActive(false);
            errorText.gameObject.SetActive(true);
            errorText.text = "Please Enter A Valid Number, hit Reset to try again";
            dealButton.gameObject.SetActive(false);
            betButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(true);
            betButton2.gameObject.SetActive(false);
        }
        else{
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
        //if(playerScript.hand[0].GetComponent<CardInfo>().value == playerScript.hand[1].GetComponent<CardInfo>().value){
           // splitButton.gameObject.SetActive(true);
        //}
        //else{
           //splitButton.gameObject.SetActive(false);
        //}
        if(playerScript.handValue >= 9 && playerScript.handValue <= 11){
            doubleButton.gameObject.SetActive(true);
        }
        else{
            doubleButton.gameObject.SetActive(false);
        }
        }
    }


    //function to add a card to a players hand
    private void hitClicked(){      
        playerScript.getCard(); //give player new card
        scoreText.text = "player: " + playerScript.handValue.ToString(); //updates text of value
        if (playerScript.handValue > 21) roundOver();//IF PLAYER BUST
        
    }
    
    //Funtion to end the players turn when they hit stand
    private void standClicked(){
        hitDealer(); //dealer hits if under 17.
        roundOver(); //will determine who wins
    }

    //Function to handle the dealer adding cards until the reach 17 in value
    private void hitDealer()
    {
        while (dealerScript.handValue < 17)
        {
            dealerScript.getCard();        
            dealerScore.text = "dealer: " + dealerScript.handValue.ToString();
        }
    }

    //Function for handling an insurance bet
    private void insuranceClicked(){
        insuranceCheck = true;
        playerScript.adjustBalance(-(currentBet/2)); //removes placed bet from playerbalance
        insuranceWager = currentBet;
        insuranceSign.gameObject.SetActive(true);
    }

    /*
    //Funtion to handle when the player wants to split their cards
    private void splitClicked(){
        splitButton.gameObject.SetActive(false);
        splitCheck = true;
        //makes two hands each with one card, and add a card to each
        splitScript1.hand[0] = playerScript.hand[0];
        splitScript2.hand[0] = playerScript.hand[1];

        //incrementing the split hands deck index
        splitScript1.cardIndex++;
        splitScript2.cardIndex++;


        //emptying the players hand since their cards are in different hands no
        playerScript.resetHand();
        splitScript1.getCard();
        splitScript2.getCard();

        //Activating all of the buttons for the two split hands while turning off the single hand buttons
        hand1Hit.gameObject.SetActive(true);
        hand1Stand.gameObject.SetActive(true);
        hand2Hit.gameObject.SetActive(true);
        hand2Stand.gameObject.SetActive(true);
        hitButton.gameObject.SetActive(false);
        standButton.gameObject.SetActive(false);
        splitScore1Text.gameObject.SetActive(true);
        splitScore2Text.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        splitScore1Text.text = "player: " + splitScript1.handValue.ToString();
        splitScore2Text.text = "player: " + splitScript2.handValue.ToString();

        playerScript.resetHand();

        //takes money and makes second pool
        playerScript.adjustBalance(-currentBet);
        splitWager = currentBet;
    }

    //Below are all of the hit/stand functions for the split hands after the player splits their cards
    private void hand1HitClicked(){      
        splitScript1.getCard(); //give player new card
        splitScore1Text.text = "player: " + splitScript1.handValue.ToString(); //updates text of value
        if (splitScript1.handValue > 21) hand1StandClicked();//IF PLAYER BUST
        
    }
    
    private void hand1StandClicked(){
        splitHand1Stand = true;
        hand1Hit.gameObject.SetActive(false);
        hand1Stand.gameObject.SetActive(false);
        //Checking if the second hand is done
        if(splitHand2Stand = false){
            hitDealer(); //dealer hits if under 17.
            roundOver(); //will determine who wins
        }

    }
    
    private void hand2HitClicked(){      
        splitScript2.getCard(); //give player new card
        splitScore2Text.text = "player: " + splitScript2.handValue.ToString(); //updates text of value
        if (splitScript2.handValue > 21) hand2StandClicked();//IF PLAYER BUST
        
    }
    
    private void hand2StandClicked(){
        splitHand2Stand = true;
        hand2Hit.gameObject.SetActive(false);
        hand2Stand.gameObject.SetActive(false);
        //Checking if hand 1 is also finished, if so then it ends the round
        if(splitHand1Stand = false){
            hitDealer(); //dealer hits if under 17.
            roundOver(); //will determine who wins
        }
    }
    */

    //Funtion for when the player doubles
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

    //Funtion for a reset button for when the player wants tos tart a new hand
    private void resetClicked(){
        //resets round, empties player&dealerhand
        playerScript.resetHand();
        dealerScript.resetHand(); 
        //splitScript1.resetHand();
        //splitScript2.resetHand();  
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
        //splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        helpButton.gameObject.SetActive(true);
        resetButton.gameObject.SetActive(false);
        escapeButton.gameObject.SetActive(true);
        helpScreen.gameObject.SetActive(false);
        insuranceSign.gameObject.SetActive(false);
       // hand1Hit.gameObject.SetActive(false);
       // hand1Stand.gameObject.SetActive(false);
        //hand2Hit.gameObject.SetActive(false);
        //hand2Stand.gameObject.SetActive(false);
       // splitScore1Text.gameObject.SetActive(false);
       // splitScore2Text.gameObject.SetActive(false);
        errorText.gameObject.SetActive(false);
    }


    //Turns on Help Panel
    private void helpClicked(){
        helpScreen.gameObject.SetActive(true);

    }

    //Turns Off help panel
    private void escapeClicked(){
        helpScreen.gameObject.SetActive(false);
    }


    //Funtion to end the round
    void roundOver()
    { 
        //check for busts
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;


        //Checking for Insurance Payout   
        if(insuranceCheck == true){
            if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue && dealerScript.handValue == 21))
        {
            mainText.text = "DEALER WINS, Insurance Pays Out";
            playerScript.adjustBalance(insuranceWager);
        }
        else if(playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "DEALER WINS, Insurance Fails";
        }
        }

        //if player busts or if dealer has higher hand. dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
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
        dealButton.gameObject.SetActive(false);
        betButton.gameObject.SetActive(false);
        betButton2.gameObject.SetActive(false);
        mainText.gameObject.SetActive(true);
        dealerScore.gameObject.SetActive(true);
        insuranceButton.gameObject.SetActive(false);
        //splitButton.gameObject.SetActive(false);
        doubleButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(true);
        helpButton.gameObject.SetActive(true);
        insuranceSign.gameObject.SetActive(false);
        hideCard.GetComponent<Renderer>().enabled = false;
        cashText.text = "Balance: $" + playerScript.getBalance().ToString();
        wager = 0;
        insuranceWager = 0;
        splitWager = 0;
        insuranceCheck = false;
        //splitCheck = false;   

    }  


    //A funtion to leave the blackjack table and return to the hub world
    private void exitClicked(){
        
    }
}
