using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Globalization;

public class CardDeck : MonoBehaviour{  
  
    public Sprite[] cardSprites; //53 of these. each sprite is image for each card. sprites can be seen by clicking the 'deck' object in unity
    int[] cardValues = new int[53]; //53 card id's
    int currentIndex = 0;

    public int value = 0;

    
    void getCardValues(){
        int num = 0;  
        for (int i = 0; i < cardSprites.Length; i++) //loops for all 52 cards in a deck
        {
            num = i; //sets num to current index of deck. 0-52. think 1-13 = clubs. 14-26 diamonds. 27-39 hearts. CAN BE SEEN BY CLICKING ON THE 'deck' object in unity!!!!!!!!!

            num %= 13; //used to make sure that the club1(1) = 1 but also diamond1(14) = 1 as well.
            if (num > 10 || num == 0) //for when num=,11,12,13. aka the face cards
            {
                num = 10; //makes sure facecards have value of 10!
            }
            cardValues[i] = num++; 
        }
    }


    public int dealCard(CardInfo cardInfo)
    {
        cardInfo.setSprite(cardSprites[currentIndex]); //set sprite (image of card)
        cardInfo.setValue(cardValues[currentIndex]);   //set value of card to match sprite. ie a 7of hearts is actually worth 7
        currentIndex++;
        return cardInfo.getValueOfCard();

    }

    public void Shuffle(){
        for (int i = cardSprites.Length - 1; i > 0; --i)
        {
            int j = Mathf.FloorToInt(UnityEngine.Random.Range(0.0f, 1.0f) * (cardSprites.Length - 1)) + 1; //generate random index to swap
           
            Sprite temp = cardSprites[i];     //swaps two random cards 
            cardSprites[i] = cardSprites[j];
            cardSprites[j] = temp;

            int value = cardValues[i];      //swaps the values for affected sprites
            cardValues[i] = cardValues[j];
            cardValues[j] = value;
        }
        currentIndex = 1;
    }

    // Start is called before the first frame update
    void Start(){
        getCardValues(); //generates deck
    }

    public Sprite getCardBack()
    {
        return cardSprites[0]; //sets sprite to 0. the 'back of card'
    }   
}

