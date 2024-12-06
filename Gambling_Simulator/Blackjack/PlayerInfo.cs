using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{ //BOTH THE PLAYER AND DEALER SHARE THIS SCRIPT AND ARE CONSIDERED 'PLAYERS'

    public CardDeck cardDeck;
    public CardInfo cardInfo;

    public int handValue=0;
    private int balance = 1000; 
    //Checking the first card if its an ace, doing this for insurance bet
    public bool card1Ace = false;

    public GameObject[] hand; //collection of cards
    public int cardIndex = 0;  //index of next card in deck
    

    //tracking aces for 1 to 11 conversions
    List<CardInfo> aceList = new List<CardInfo>();

    public void startHand() //gives two cards at start of hand
    {
        getCard();
        if(handValue == 11){
            card1Ace = true;
        }
        getCard();
        
    }

    //determines if ace should be worth 1 or 11 
    public void aceCheck()
    {
        //for each ace in the list check
        foreach (CardInfo ace in aceList)
        {
            if (handValue + 10 < 22 && ace.getValueOfCard() == 1) //if 11 will NOT bust hand make soft 11.
            {  
                ace.setValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.getValueOfCard() == 11) //if the ace will now BUST hand, make 1.
            {
                ace.setValue(1);
                handValue -= 10;
            }
        }
    }

    //add card to the player/dealer hand
    public int getCard()
    {
        //uses dealCard function from CardDeck.cs to assign sprite and value to new card on table
        int cardValue = cardDeck.dealCard(hand[cardIndex].GetComponent<CardInfo>());
        
        hand[cardIndex].GetComponent<Renderer>().enabled = true; //makes sure the given card is actually shown on screen
        handValue += cardValue; //add new card value to running total of the hand

        
        if (cardValue == 1) aceList.Add(hand[cardIndex].GetComponent<CardInfo>()); //if new card value is 1 is ace, add to acelist for check 
        aceCheck(); //determines if 11 or 1 if any ace
        cardIndex++; //counts how many cards player has

        return handValue;
    }

    public int getBalance()
    {
        return balance; //returns player balance
    }

    public void adjustBalance(int amount)
    {
        balance += amount;
    }

    public void resetHand()
    {
        for (int i = 0; i < hand.Length; i++) //hand.length refers to card1,card2,hit1,hit2,etc...
        {
            hand[i].GetComponent<CardInfo>().resetCard();//resets the cards back to index 0, the 'back of the card'
            hand[i].GetComponent<Renderer>().enabled = false; //hides all cards to player, ie hit cards now cant be seen on new hand
        }
        cardIndex = 0;
        handValue = 0; 
        card1Ace = false;
        aceList = new List<CardInfo>(); //resets any ace count
    }
 
}
