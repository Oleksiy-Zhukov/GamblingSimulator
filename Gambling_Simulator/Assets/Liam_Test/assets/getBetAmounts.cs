using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace CrapsGame{
public class getBetAmounts: MonoBehaviour{

    public int value=0;
    public Canvas Canvas;
   public GameObject five;
   public GameObject ten;
    public GameObject twofive;
    public GameObject fifty;

    public Craps crapsGame; // Reference to the Craps game

    public GameObject no;

      private GameObject fivedolla;
      private  GameObject tendolla;
      private GameObject twentyfivedolla;
      private GameObject fiftydolla;

       private GameObject q;




public void fart() { 

    fivedolla=Instantiate(five,Canvas.transform);
      tendolla=Instantiate(ten,Canvas.transform);
  twentyfivedolla=Instantiate(twofive,Canvas.transform);
   fiftydolla=Instantiate(fifty,Canvas.transform);
   q=Instantiate(no,Canvas.transform);

  fivedolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(5));

  tendolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(10));

  twentyfivedolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(25));

  fiftydolla.GetComponent<Button>().onClick.AddListener(() => UpdateValue(50));

  q.GetComponent<Button>().onClick.AddListener(() => quit());

  


}

public void quit(){



}


public void UpdateValue(int index)
    {
        // Increment the value associated with this button
        value=index;
        
      Destroy(q);
      Destroy(fivedolla);
      Destroy(tendolla);
      Destroy(twentyfivedolla);
      Destroy(fiftydolla);

      crapsGame.PlayGame();

    }


}


}
