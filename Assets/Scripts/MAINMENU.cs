using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MAINMENU : MonoBehaviour
{
    public Button playButton;
    public GAMEMANAGER GameManager;
    // Start is called before the first frame update
    void Start()
    {
        if(playButton){
            if(GameManager.CharactersCount == 0){playButton.interactable = false;}
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playButton){
            if(playButton.interactable == false && GameManager.CharactersCount > 0){
                playButton.interactable = true;
            }
            if(playButton.interactable == true && GameManager.CharactersCount < 1){
                playButton.interactable = false;
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
