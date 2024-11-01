using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScene : MonoBehaviour
{
    private string scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = transform.parent.name;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.G))
            {
                SceneManager.LoadScene(scene);
            }
        }
    }
}
