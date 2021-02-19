using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
    public static string previousScene = "Main";
    public static int charactersCount = 0;
    public Button playButton;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Game Manager - in start function.");
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

    public void onExitClicked(){
        Debug.Log("Exiting Game. Have a nice day!");
        Application.Quit();
    }

    public void onMainMenuClicked(){
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene("Main");
    }

    public void onNewCharacterClicked(){
        Debug.Log("Creating new character.");
        previousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("NewCharacter");
    }

    public void onBackButtonClicked(){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(previousScene);
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void onPlayButtonClicked(){

    }
    
    public void saveNewCharacter(InputField CharNameInputField){
        string charName = CharNameInputField.text;
        Debug.Log($"Saving new character named {charName}");
        charactersCount++;
    }
}
