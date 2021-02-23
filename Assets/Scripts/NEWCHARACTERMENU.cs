using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWCHARACTERMENU : MonoBehaviour
{
    public GAMEMANAGER GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButtonClicked(){
        if(SceneManager.GetActiveScene().name != "NewCharacter"){
            GameManager.HideWindow(transform.parent.gameObject);
        }
        else{
            GameManager.LoadPreviousScene();
        }
    }

    public void OnSaveButtonClicked(InputField NameInput){
        GameManager.SaveNewCharacter(NameInput);
    }

}
