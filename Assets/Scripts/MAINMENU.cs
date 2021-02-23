using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public Button playButton;
    public Object GameManager;
    public static int charactersCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(charactersCount == 0){
            if(playButton){playButton.interactable = false;}
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playButton){
            if(playButton.interactable == false && charactersCount > 0){
                playButton.interactable = true;
            }
        }
        
    }

    public void OnBackButtonClicked(){
    
    }

    public void OnNewCharacterClicked(){
        Debug.Log("Creating new character.");
        SceneManager.LoadScene("NewCharacter");
    }

    public void OnOptionsButtonClicked(){

    }

    public void OnPlayButtonClicked(){

    }
}
