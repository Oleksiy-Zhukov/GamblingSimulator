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

    public GameObject finish;
    public Craps crapsGame; // Reference to the Craps game

    public GameObject no;

    public GameObject pas;
    public GameObject dontpas;
    

      private GameObject fivedolla;
      private  GameObject tendolla;
      private GameObject twentyfivedolla;
      private GameObject fiftydolla;

      private GameObject pass;
      private GameObject dontpass;

       private GameObject q;

       private GameObject don;

      public bool passBet;


public void fart() { 

    fivedolla=Instantiate(five,Canvas.transform);
      tendolla=Instantiate(ten,Canvas.transform);
  twentyfivedolla=Instantiate(twofive,Canvas.transform);
   fiftydolla=Instantiate(fifty,Canvas.transform);
   q=Instantiate(no,Canvas.transform);
   don = Instantiate(finish,Canvas.transform);

  fivedolla.GetComponent<Button>().onClick.AddListener(() => value += 5);

  tendolla.GetComponent<Button>().onClick.AddListener(() => value += 10);

  twentyfivedolla.GetComponent<Button>().onClick.AddListener(() => value += 25);

  fiftydolla.GetComponent<Button>().onClick.AddListener(() => value += 50);

  q.GetComponent<Button>().onClick.AddListener(() => quit());

  don.GetComponent<Button>().onClick.AddListener(() => UpdateValue());





  


}

public void quit(){



}


public void UpdateValue()
    {

      Destroy(q);
      Destroy(fivedolla);
      Destroy(tendolla);
      Destroy(twentyfivedolla);
      Destroy(fiftydolla);
      Destroy(don);

      pass= Instantiate(pas,Canvas.transform);
      dontpass=Instantiate(dontpas,Canvas.transform);


        pass.GetComponent<Button>().onClick.AddListener(() => play(true));

  dontpass.GetComponent<Button>().onClick.AddListener(() => play(false));

      
    }

public void play(bool pss)
{
  passBet=pss;
  Destroy(pass);
  Destroy(dontpass);
  crapsGame.PlayGame(passBet);

}

}


}
