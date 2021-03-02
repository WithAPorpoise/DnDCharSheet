using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GAMEMANAGER : Singleton<GAMEMANAGER>
{

    public string PreviousScene = "Main";
    public int CharactersCount = 0;
    public Button BackButton;
    public Button SaveButton;
    [SerializeField]
    protected List<PlayerCharacter> NPCList = new List<PlayerCharacter>();
    [SerializeField]
    protected PlayerCharacter PC;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Game Manager: starting.");
        SetupIfSetupHasNotRun();
    }

    // Update is called once per frame
    void Update()
    {
    }


    protected override void Setup(){
        PC = new PlayerCharacter();
        if (this.HasNulls()){
                Debug.LogError(this + "has null values.");
            }    
        
    }

    //public T[] PopulateDropdown<T>(string type){
    //}

    public void OnMainMenuClicked(){
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene(0);
    }


    public void LoadPreviousScene(){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PreviousScene = SceneManager.GetActiveScene().name;
    }

    public void LoadPreviousScene(string sceneName){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(sceneName);
        PreviousScene = SceneManager.GetActiveScene().name;
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
        CharactersCount++;
        string characterPath = Application.persistentDataPath + PC.characterName+ (".json");
        SaveObjectData<PlayerCharacter>(PC, characterPath);
    }

    public T LoadObjectData<T>(string path){
        string jsonString = File.ReadAllText(path);
        T data = JsonUtility.FromJson<T>(jsonString);
        return data;
    }  

    public void SaveObjectData<T>(T obj, string path){
        string jsonString = JsonUtility.ToJson(obj, true);
        File.WriteAllText(path,jsonString);
    }
    
    public void OnExitClicked(){
        Debug.Log("Exiting Game. Have a nice day!");
        Application.Quit();
    }

    public void HideWindow(GameObject window){
        window.SetActive(false);
    }

    public void UpdateRace(string raceName, PlayerCharacter player){
        
    }
    public bool HasNulls(){
        return(PC==null||BackButton==null||SaveButton==null);
    }
}
