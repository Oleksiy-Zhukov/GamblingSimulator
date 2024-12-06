using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class ROLL : MonoBehaviour{
    
    int dice1;
    int dice2;

    public diceDisplay diceone;
    public diceDisplay dicetwo;

    public void diceroll(){
        dice1=RandomNumberGenerator.GetInt32(1,7);
        dice2=RandomNumberGenerator.GetInt32(1,7);


        diceone.ChangeSprite(dice1-1);
        dicetwo.ChangeSprite(dice2-1);
        

    }

    public int GetDiceSum()
    {
        return dice1 + dice2;
    }
    


}
