using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class getBetType: MonoBehaviour{

    public int betNum;
    public Canvas Canvas;
   public GameObject pass;
   public GameObject dont;




public void getBet() { 

    pass=Instantiate(pass,Canvas.transform);
    dont=Instantiate(dont,Canvas.transform);


  pass.GetComponent<Button>().onClick.AddListener(() => UpdateValue(5));

  dont.GetComponent<Button>().onClick.AddListener(() => UpdateValue(10));


}

void UpdateValue(int index)
    {
        // Increment the value associated with this button
        betNum=index;
        

      Destroy(pass);
      Destroy(dont);

    }


}



