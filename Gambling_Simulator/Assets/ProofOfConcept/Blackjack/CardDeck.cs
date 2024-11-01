using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CardDeck : MonoBehaviour{
  
    //public Card thisCard;
    public Card[] deck;
    public int index;
    //public string cardInfo;
    //public GameObject cardImage;
    public Text cardInfoText1;
    public Text cardInfoText2;
    public Text cardInfoText3;
    public void Click()
    {
        Shuffle();

        cardInfoText1.text = deck[0].value + " of " + deck[0].suit.ToString();
        cardInfoText2.text = deck[1].value + " of " + deck[1].suit.ToString();
        cardInfoText3.text = deck[2].value + " of " + deck[2].suit.ToString();
    }

    public void DisplayCard(Card C)
    {


    }

    public void Shuffle(){
        int shuffles = UnityEngine.Random.Range(111, 1111); 

        for (int i = 0; i < shuffles; i++) //shuffles anywhere from 111-1111 cards
        {
            int index = UnityEngine.Random.Range(0, 52); //chooses random card in deck to replace
            int index2 = UnityEngine.Random.Range(0, 52); //chooses random card in deck to replace

            Card firstCard = deck[index];  //gets information of first card 
            Card secondCard = deck[index2]; //gets information of second card 
            Card tempCard = deck[index]; //holds information of first card for later swap


            firstCard = secondCard; //swaps first card with second
            secondCard = tempCard;  //swaps second card with first

            deck[index] = firstCard;  //places changed card into deck
            deck[index2] = secondCard; //places changed card into deck
        }
    }

    // Start is called before the first frame update
    void Start(){
        deck = new Card[52]; //initialize deck of size 52
        index = 0;

        for (int i = 0; i < 13; i++){ //for all possible cards 1-10 jkq
            Card temp = new Card();
            temp.value = i;
            temp.suit = Card.Suit.clubs;
            deck[index] = temp;
            index++;
        }

        for (int i = 0; i < 13; i++){ //for all possible cards 1-10 jkq      
            Card temp = new Card();
            temp.value = i;
            temp.suit = Card.Suit.spades;
            deck[index] = temp;
            index++;
        }

        for (int i = 0; i < 13; i++){ //for all possible cards 1-10 jkq       
            Card temp = new Card();
            temp.value = i;
            temp.suit = Card.Suit.diamonds;
            deck[index] = temp;
            index++;
        }

        for (int i = 0; i < 13; i++){ //for all possible cards 1-10 jkq      
            Card temp = new Card();
            temp.value = i;
            temp.suit = Card.Suit.hearts;
            deck[index] = temp;
            index++;
        }

       // Shuffle();
    }

    // Update is called once per frame
    void Update(){
        
    }
}


[Serializable]
public class Card{
    public int value;
    public enum Suit {clubs, spades, diamonds, hearts};
    public Suit suit;
}