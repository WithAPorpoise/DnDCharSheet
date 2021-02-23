using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAMEMANAGER : MonoBehaviour
{
    public static string previousScene = "Main";
    public static int charactersCount = 0;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Game Manager: starting.");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMainMenuClicked(){
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene(0);
    }


    public void LoadPreviousScene(){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void LoadPreviousScene(string sceneName){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(sceneName);
        previousScene = SceneManager.GetActiveScene().name;
    }

    public void LoadNextScene(){
        Debug.Log("Loading next scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadNextScene(string sceneName){
        Debug.Log("Loading next scene.");
        SceneManager.LoadScene(sceneName);
    }
    
    public void SaveNewCharacter(InputField CharNameInputField){
        string charName = CharNameInputField.text;
        Debug.Log($"Saving new character named {charName}");
        charactersCount++;
    }
    
    public void OnExitClicked(){
        Debug.Log("Exiting Game. Have a nice day!");
        Application.Quit();
    }

    public void HideWindow(GameObject window){
        window.SetActive(false);
    }
}
