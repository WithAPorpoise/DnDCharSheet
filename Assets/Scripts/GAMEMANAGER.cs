using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEMANAGER : MonoBehaviour
{
    public static scene previousScene;
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
        Application.Quit();
    }

    public void onMainMenuClicked(){
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene("Main");
    }

    public void onNewCharacterClicked(){
        Debug.Log("Creating new character.");
        previousScene = Scene.name;
        SceneManager.LoadScene("NewCharacter");
    }

    public void onBackButtonClicked(){
        
        Debug.Log("Creating new character.");
        previousScene = Scene.name;
        SceneManager.LoadScene(previousScene);
    }
}
