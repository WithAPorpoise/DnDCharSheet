using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWCHARACTERMENU : MonoBehaviour
{
    public GAMEMANAGER GameManager;
    public GameObject RaceClassPanel;
    public GameObject RaceDropdown;
    public GameObject SubraceDropdown;
    public GameObject ClassDropdown;
    public GameObject SubclassDropdown;
    public BaseRaceList baseRaces = new BaseRaceList();
    public BaseClassList baseClasses = new BaseClassList();
    public List<TextAsset> jsonFiles;
    public List<int> dieRolls;
    private string data;

    // Start is called before the first frame update
    void Start()
    {
        if(jsonFiles.Count == 0){
            jsonFiles = new List<TextAsset>(Resources.LoadAll<TextAsset>("Data/PlayData"));
        }

        baseClasses = JsonUtility.FromJson<BaseClassList>(jsonFiles[0].text);
        baseRaces = JsonUtility.FromJson<BaseRaceList>(jsonFiles[1].text);
        RaceDropdown = GameObject.Find("RaceDropdown");
        RaceDropdown.GetComponent<Dropdown>().ClearOptions();
        RaceDropdown.GetComponent<Dropdown>().AddOptions(new List<string>(){"Base Race"});
        RaceDropdown.GetComponent<Dropdown>().AddOptions(baseRaces.GetListOfProperty("names"));
        SubraceDropdown = GameObject.Find("SubraceDropdown");
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        SubraceDropdown.SetActive(false);
        ClassDropdown = GameObject.Find("ClassDropdown");
        ClassDropdown.GetComponent<Dropdown>().ClearOptions();
        ClassDropdown.GetComponent<Dropdown>().AddOptions(new List<string>(){"Base Class"});
        
        ClassDropdown.GetComponent<Dropdown>().AddOptions(baseClasses.GetListOfProperty("names"));
        SubclassDropdown = GameObject.Find("SubclassDropdown");
        SubclassDropdown.GetComponent<Dropdown>().ClearOptions();
        SubclassDropdown.SetActive(false);
        /*
        if(SubraceDropdown = null){
        SubraceDropdown = GameObject.Find("SubraceDropdown");
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        }
        if(SubclassDropdown = null){
            
        SubclassDropdown = GameObject.Find("SubclassDropdown");
        SubclassDropdown.GetComponent<Dropdown>().ClearOptions();
        }
        */
    }

    // Update is called once per frame
    void Update()
    { 
        if(!SubraceDropdown.activeSelf  &&  RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Base Race"){
            SubraceDropdown.SetActive(true);
        }
        if(SubraceDropdown.activeSelf  &&  RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Base Race"){
            SubraceDropdown.SetActive(false);
        }
        if(!SubclassDropdown.activeSelf && ClassDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Base Class" ){            
            SubclassDropdown.SetActive(true);
        }
        if(SubclassDropdown.activeSelf && ClassDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Base Class" ){            
            SubclassDropdown.SetActive(false);
        }
    }

    void OnEnable(){
    }    

    public void OnBackButtonClicked(){
        if(SceneManager.GetActiveScene().name != "NewCharacter"){
            GameManager.HideWindow(transform.parent.gameObject);
        }
        else{
            GameManager.LoadPreviousScene();
        }
    }

    public void OnSaveButtonClicked(){
        GameManager.SaveNewCharacter();
    }
    public void PopulateDropdown(Dropdown dropdown, GameObject[] optionsArray){
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach(var option in optionsArray){
            options.Add(option.name);
        }
        dropdown.AddOptions(options);
    }
    public void PopulateDropdown(Dropdown dropdown, ScriptableObject[] optionsArray){
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        foreach(var option in optionsArray){
            options.Add(option.name);
        }
        dropdown.AddOptions(options);
    }
    public void PopulateDropdown(Dropdown dropdown, List<string> options){
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void UpdateNewCharacter(GameObject dataField){
        GameManager.UpdateCharacterData(GameManager.PC, dataField.transform.parent.gameObject.tag, dataField.GetComponent<Text>().text);
    }

    public void RollAbilities(){
        List<int> currentRolls;
        for(int i = 0; i< 6; i++){
            
        }
    }
}
