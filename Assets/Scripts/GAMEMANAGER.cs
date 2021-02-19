using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAMEMANAGER : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Manager - in start function.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitClicked(){
        Debug.Log("Exiting Game. Have a nice day!");
    }
}
