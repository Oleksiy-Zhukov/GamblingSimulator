using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class playMore: MonoBehaviour{

    public int yesNo;
    public Canvas Canvas;
   public GameObject yes;
   public GameObject no;




public void play() { 

    yes=Instantiate(yes,Canvas.transform);
    no=Instantiate(no,Canvas.transform);


  yes.GetComponent<Button>().onClick.AddListener(() => UpdateValue(1));

  no.GetComponent<Button>().onClick.AddListener(() => UpdateValue(0));


}

void UpdateValue(int index)
    {
        // Increment the value associated with this button
        yesNo=index;
        

      Destroy(yes);
      Destroy(no);

    }


}



