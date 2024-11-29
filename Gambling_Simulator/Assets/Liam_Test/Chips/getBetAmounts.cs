using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class getBetAmounts: MonoBehaviour{

    public int value;
    public Canvas Canvas;
   public GameObject five;
   public GameObject ten;
    public GameObject twofive;
    public GameObject fifty;

      private GameObject fivedolla;
      private  GameObject tendolla;
      private GameObject twentyfivedolla;
      private GameObject fiftydolla;




public void fart() { 

    fivedolla=Instantiate(five,Canvas.transform);
      tendolla=Instantiate(ten,Canvas.transform);
  twentyfivedolla=Instantiate(twofive,Canvas.transform);
   fiftydolla=Instantiate(fifty,Canvas.transform);

  fivedolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(5));

  tendolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(10));

  twentyfivedolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(25));

  fiftydolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(50));

}

  void UpdateValue(int index)
    {
        // Increment the value associated with this button
        value=index;
        

      Destroy(fivedolla);
      Destroy(tendolla);
      Destroy(twentyfivedolla);
      Destroy(fiftydolla);

    }



}



