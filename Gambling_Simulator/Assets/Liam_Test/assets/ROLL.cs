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
        dice1=RandomNumberGenerator.GetInt32(0,6);
        dice2=RandomNumberGenerator.GetInt32(0,6);

        diceone.ChangeSprite(dice1);
        dicetwo.ChangeSprite(dice2);

    }


    


}
