using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoBehaviourWithSetup : MonoBehaviour
{
    private bool hasRunSetup = false;
    // Start is called before the first frame update
    void Start()
    {
        SetupIfSetupHasNotRun();
    }

    // Update is called once per frame

    public void SetupIfSetupHasNotRun(){
        if(!hasRunSetup){
            hasRunSetup = true;
            Setup();
        }
    }

    protected abstract void Setup();
}
