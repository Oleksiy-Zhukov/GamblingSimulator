using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour //EACH CARD HAS THIS SCRIPT. STORING VALUE OF THE CARD
{
    public int value = 0; //value, ie king=10, 3=3, etcetc

    public int getValueOfCard()
    {
        return value; 
    }

    public void setValue(int newValue) //used for setting ace value in playerinfo.cs
    {
        value = newValue;
    }

    public string getSpriteName()
    {
        return GetComponent<SpriteRenderer>().sprite.name; 
    }

    public void setSprite(Sprite newSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void resetCard()
    {
        Sprite back = GameObject.Find("deck").GetComponent<CardDeck>().getCardBack();
        gameObject.GetComponent<SpriteRenderer>().sprite = back;
        value = 0;
    }
}
