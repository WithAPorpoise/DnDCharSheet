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
    public GameObject BackButton;
    public GameObject SaveButton;
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

    void OnEnable(){
        SetupIfSetupHasNotRun();
    }

    protected override void Setup(){
        PC = new PlayerCharacter();
        BackButton = GameObject.Find("BackButton");
        SaveButton = GameObject.Find("SaveButton");
        if (this.HasNulls()){
                Debug.LogError(this + "has null values.");
            }    
        
    }


    public void OnMainMenuClicked(){
        Debug.Log("Returning to main menu.");
        SceneManager.LoadScene(0);
    }


    public void LoadPreviousScene(){
        
        Debug.Log("Returning to previous scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PreviousScene = SceneManager.GetActiveScene().name;
    }

    public void LoadNextScene(){
        Debug.Log("Loading next scene.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void SaveNewCharacter(){
        
        if(PC.characterName == ""){
            PC.characterName = "New Character" + (CharactersCount + 1);
        }
        Debug.Log($"Saving new character named {PC.characterName}");
        CharactersCount++;
        string characterPath = Application.dataPath + "/Resources/Data/Characters/"+ PC.characterName + (".json");
        SaveObjectData<PlayerCharacter>(PC, characterPath);
        LoadPreviousScene();
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

    public void HideWindow(GameObject window){
        window.SetActive(false);
    }

    public void UpdateRace(string raceName, PlayerCharacter player){

    }
    public bool HasNulls(){
        return(PC==null||BackButton==null||SaveButton==null);
    }
        public void OnExitClicked(){
        Debug.Log("Exiting Game. Have a nice day!");
        Application.Quit();
    }

    public void UpdateCharacterData(PlayerCharacter pc, string field, string data){
        switch(field){
                    
                    case "characterName":
                        pc.characterName = data;
                    break;
                    case "playerName":
                        pc.playerName = data;
                    break;
                    case "playerID":
                        pc.playerID = data;
                    break;
                    case "background":
                        pc.background = data;
                    break;
                    case "charRace":
                        pc.charRace = data;
                    break;
                    case "features":
                        pc.features.Add(data);
                    break;
                    case "proficiencies":
                        pc.proficiencies.Add(data);
                    break;
                    case "spells":
                        pc.spells.Add(data);
                    break;
                    default:
                        Debug.LogError("Character Update: This string field does not exist.");
                    break;
                }
    }

    public void UpdateCharacterData(PlayerCharacter pc, string field, ClassLevel data){
            switch (field)
            {
                case "level":
                    pc.classes.Add(data);
                break;
                default:
                    Debug.LogError("Character Update: This class level field does not exist.");
                break;
            }
        
    }
    
    public void UpdateCharacterData(PlayerCharacter pc, string field, int data){
            switch (field)
            {
                case "strength":
                    pc.strength = data;
                    break;
                case "dexterity":
                    pc.dexterity = data;
                    break;
                case "constitution":
                    pc.constitution = data;
                    break;
                case "intelligence":
                    pc.intelligence = data;
                    break;
                case "wisdom":
                    pc.wisdom = data;
                    break;
                case "charisma":
                    pc.charisma = data;
                    break;
                case "speed":
                    pc.speed = data;
                    break;
                case "proficiency":
                    pc.proficiency = data;
                    break;
                case "height":
                    pc.height = data;
                    break;
                case "hitDie":
                    pc.hitDie = data;
                    break;
                case "level":
                    pc.level = data;
                    break;
                case "money":
                    pc.money = data;
                    break;
                case "health":
                    pc.health = data;
                    break;
                case "maxHealth":
                    pc.maxHealth = data;
                    break;
                default:
                    Debug.LogError("Character Update: This integer field does not exist.");
                break;
            
        }
    }
}
