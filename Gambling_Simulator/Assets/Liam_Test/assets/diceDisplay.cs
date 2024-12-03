using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceDisplay : MonoBehaviour
{
public SpriteRenderer spriteRender;
public Sprite[] spriteArray;

public void ChangeSprite(int k) 
    { 
        spriteRender.sprite = spriteArray[k]; 
    }
}
