using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class getBetAmounts: MonoBehaviour{

    public Canvas Canvas;
   public GameObject five;
   public GameObject ten;
    public GameObject twofive;
    public GameObject fifty;
public void Start() { 

      GameObject fivedolla=Instantiate(five,Canvas.transform);
      GameObject tendolla=Instantiate(ten,Canvas.transform);
      GameObject twentyfivedolla=Instantiate(twofive,Canvas.transform);
      GameObject fiftydolla=Instantiate(fifty,Canvas.transform);



}



}
