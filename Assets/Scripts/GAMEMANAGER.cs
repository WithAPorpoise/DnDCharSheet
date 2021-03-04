using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GAMEMANAGER : Singleton<GAMEMANAGER>
{

    public string PreviousScene = "Main";
    public int CharactersCount = 0;
    public GameObject BackButton;
    public GameObject SaveButton;
    public GameObject JSONViewer;
    [SerializeField]
    protected List<TextAsset> playerFiles;
    [SerializeField]
    protected List<PlayerCharacter> NPCList = new List<PlayerCharacter>();
    [SerializeField]
    public PlayerCharacter PC;
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
        playerFiles = new List<TextAsset>(Resources.LoadAll<TextAsset>("Data/Saves"));
        PC = new PlayerCharacter();
        CharactersCount = playerFiles.Count;
        BackButton = GameObject.Find("BackButton");
        SaveButton = GameObject.Find("SaveButton");
        JSONViewer = GameObject.Find("JSONViewer");
        
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
        string characterPath = Application.dataPath + "/Resources/Data/Saves/"+ PC.characterName + (".json");
        SaveObjectData<PlayerCharacter>(PC, characterPath);
        //PrintObjectData<PlayerCharacter>(PC, JSONViewer);
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

    public void PrintPlayerData(){
        string jsonString  = JsonUtility.ToJson(PC, true);
        JSONViewer.GetComponent<InputField>().text = jsonString;
    }
    /*
    public void PrintObjectData<T>(T obj, GameObject gameOb){
        string jsonString  = JsonUtility.ToJson(obj, true);
        //Text []  textObjects = gameOb.GetComponentsInChildren<Text>();
        //foreach(var child in textObjects){
        //        child.text = jsonString;   
        //}
        gameOb.GetComponent<Text>().text = jsonString; // does not work?
    }
    */

    public void HideWindow(GameObject window){
        window.SetActive(false);
    }

    public bool HasNulls(){
        return(PC==null||BackButton==null||SaveButton==null);
    }

    public void OnExitClicked(){
        if(Application.isEditor){
            Debug.Log("Exiting Game. Have a nice day!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else{
            Application.Quit();
        }
    }

    public void UpdateCharacterData(PlayerCharacter pc, string field, string data){
        switch(field.ToLower()){
                    case "strength":
                    try{
                    pc.strength = int.Parse(data);
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "dexterity":
                try{
                    pc.dexterity = int.Parse(data);
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "constitution":
                try{
                    pc.constitution = int.Parse(data);
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "intelligence":
                try{
                    pc.intelligence = int.Parse(data);
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "wisdom":
                try{
                    pc.wisdom = int.Parse(data);
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "charisma":
                try{
                    pc.charisma = int.Parse(data);
                    
                    }
                    catch(System.FormatException e){Debug.LogError(e.Message);}
                    break;
                case "speed":
                    pc.speed = float.Parse(data);
                    break;
                case "proficiency":
                    pc.proficiency = int.Parse(data);
                    break;
                case "height":
                    pc.height = int.Parse(data);
                    break;
                case "weight":
                    pc.weight = int.Parse(data);
                    break;
                case "hitdie":
                    pc.hitDie = int.Parse(data);
                    break;
                case "money":
                    pc.money = int.Parse(data);
                    break;
                case "health":
                    pc.health = int.Parse(data);
                    break;
                case "maxhealth":
                    pc.maxHealth = int.Parse(data);
                    break;
                    case "xp":
                    pc.xp = int.Parse(data);
                    break;
                    case "maxxp":
                    pc.maxXp = int.Parse(data);
                    break;
                    case "charactername":
                        pc.characterName = data;
                    break;
                    case "playername":
                        pc.playerName = data;
                    break;
                    case "playerID":
                        pc.playerID = data;
                    break;
                    case "background":
                        pc.background = data;
                    break;
                    case "charrace": case"race":
                        pc.charRace = data;
                    break;
                    case "subrace":
                        pc.subrace = data;
                    break;
                    case "class":
                        if(pc.classes.Count == pc.level){
                            pc.classes.Add(data);
                        }
                        else{
                            pc.classes[pc.level] = data;
                        }
                    break;
                    case "subclass":
                        pc.subclasses.Add(data);
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
                    case "items":
                        pc.items.Add(data);
                    break;
                    default:
                        Debug.LogError("Character Update: This string field does not exist.");
                    break;
                }
    }
    
    public int RollDie(int die){
        return (int)Mathf.Ceil(Random.Range(0.0f, 1.0f) * die);
    }

    public void UpdateLevel(PlayerCharacter pc){
        pc.level = pc.classes.Count;
    }
}
