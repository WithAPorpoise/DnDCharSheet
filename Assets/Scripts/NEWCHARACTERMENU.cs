using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NEWCHARACTERMENU : MonoBehaviour
{
    public GAMEMANAGER GameManager;
    public GameObject JSONViewer;
    public GameObject RaceClassPanel;
    public GameObject RaceDescription;
    public GameObject ClassDescription;

    public GameObject RaceDropdown;
    public GameObject SubraceDropdown;
    public GameObject ClassDropdown;
    public GameObject SubclassDropdown;
    public GameObject StrengthDropdown;
    public GameObject DexterityDropdown;
    public GameObject ConstitutionDropdown;
    public GameObject IntelligenceDropdown;
    public GameObject WisdomDropdown;
    public GameObject CharismaDropdown;

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
        JSONViewer = GameObject.Find("JSONViewer");

        baseClasses = JsonUtility.FromJson<BaseClassList>(jsonFiles[0].text);
        baseRaces = JsonUtility.FromJson<BaseRaceList>(jsonFiles[1].text);
        RaceDropdown = GameObject.Find("RaceDropdown");
        RaceDropdown.GetComponent<Dropdown>().ClearOptions();
        RaceDropdown.GetComponent<Dropdown>().AddOptions(new List<string>(){"Choose Option"});
        RaceDropdown.GetComponent<Dropdown>().AddOptions(baseRaces.GetListOfProperty("names"));
        SubraceDropdown = GameObject.Find("SubraceDropdown");
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        SubraceDropdown.SetActive(false);
        ClassDropdown = GameObject.Find("ClassDropdown");
        ClassDropdown.GetComponent<Dropdown>().ClearOptions();
        ClassDropdown.GetComponent<Dropdown>().AddOptions(new List<string>(){"Choose Option"});
        
        ClassDropdown.GetComponent<Dropdown>().AddOptions(baseClasses.GetListOfProperty("names"));
        SubclassDropdown = GameObject.Find("SubclassDropdown");
        SubclassDropdown.GetComponent<Dropdown>().ClearOptions();
        SubclassDropdown.SetActive(false);

        StrengthDropdown = GameObject.Find("StrengthDropdown");
        DexterityDropdown = GameObject.Find("DexterityDropdown");
        ConstitutionDropdown = GameObject.Find("ConstitutionDropdown");
        IntelligenceDropdown = GameObject.Find("IntelligenceDropdown");
        WisdomDropdown = GameObject.Find("WisdomDropdown");
        CharismaDropdown = GameObject.Find("CharismaDropdown");
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
        if(!SubraceDropdown.activeSelf  &&  RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Choose Option"){
            SubraceDropdown.SetActive(true);
            RaceDescription.SetActive(true);
        }
        if(SubraceDropdown.activeSelf  &&  RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Choose Option"){
            SubraceDropdown.SetActive(false);
            RaceDescription.SetActive(false);
        }
        if(!SubclassDropdown.activeSelf && ClassDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text != "Choose Option" ){            
            SubclassDropdown.SetActive(true);
        }
        if(SubclassDropdown.activeSelf && ClassDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Choose Option" ){            
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
        UpdateNewCharacter(RaceDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(SubraceDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(ClassDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(SubclassDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(StrengthDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(DexterityDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(ConstitutionDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(IntelligenceDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(WisdomDropdown.transform.GetChild(0).gameObject);
        UpdateNewCharacter(CharismaDropdown.transform.GetChild(0).gameObject);
        UpdateProficiency();
        GameManager.SaveNewCharacter();
    }
    public void PopulateDropdown(Dropdown dropdown, GameObject[] optionsArray){
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("Choose Option");
        foreach(var option in optionsArray){
            options.Add(option.name);
        }
        dropdown.AddOptions(options);
    }
    public void PopulateDropdown(Dropdown dropdown, ScriptableObject[] optionsArray){
        dropdown.ClearOptions();
        List<string> options = new List<string>();
        options.Add("Choose Option");
        foreach(var option in optionsArray){
            options.Add(option.name);
        }
        dropdown.AddOptions(options);
    }
    public void PopulateDropdown(Dropdown dropdown, List<string> options){
        dropdown.ClearOptions();
        options.Add("Choose Option");
        dropdown.AddOptions(options);
    }
    public void PopulateDropdown(Dropdown dropdown, List<int> options){
        dropdown.ClearOptions();
        List<string> stringOptions = new List<string>();
        stringOptions.Add("Choose Option");
        foreach (var item in options)
        {
            stringOptions.Add(item.ToString());
        }
        dropdown.AddOptions(stringOptions);
    }

    public void UpdateNewCharacter(GameObject dataField){
        GameManager.UpdateCharacterData(GameManager.PC, dataField.transform.parent.gameObject.tag.ToString(), dataField.GetComponent<Text>().text);
    }

    public void PrintPlayerData(){
        string jsonString  = JsonUtility.ToJson(GameManager.PC, true);
        JSONViewer.GetComponent<InputField>().text = jsonString;
    }
    public void OnRollButtonPressed(GameObject label){
        switch(label.GetComponent<Text>().text){
            case "Roll & Assign":
                RollAbilities();
                
                PopulateDropdown(StrengthDropdown.GetComponent<Dropdown>(), dieRolls);
                PopulateDropdown(DexterityDropdown.GetComponent<Dropdown>(), dieRolls);
                PopulateDropdown(ConstitutionDropdown.GetComponent<Dropdown>(), dieRolls);
                PopulateDropdown(IntelligenceDropdown.GetComponent<Dropdown>(), dieRolls);
                PopulateDropdown(WisdomDropdown.GetComponent<Dropdown>(), dieRolls);
                PopulateDropdown(CharismaDropdown.GetComponent<Dropdown>(), dieRolls);
            break;
        }
        
    }

    public void UpdateProficiency(){
        int prof = (int)Mathf.Floor(GameManager.PC.classes.Count/4) +2;
        GameManager.UpdateCharacterData(GameManager.PC, "proficiency", prof.ToString());
    }

    public void RollAbilities(){
        List<int> abilitiesList = new List<int>();
        for(int i = 0; i< 6; i++){
            List<int> currentRolls = new List<int>();
            for(int j=0; j<4; j++){
                currentRolls.Add(GameManager.RollDie(6));
            }
            currentRolls.Sort();
            currentRolls.Remove(currentRolls[0]);
            int sum = 0;
            foreach (var item in currentRolls)
            {
                sum+= item;
            }
            abilitiesList.Add(sum);
        }
        dieRolls = abilitiesList;
    }

    public string GetRaceTrait(string trait){
        string traitOutput = "";
        switch (trait.ToLower()){
            case "feat": case "feature":

            break;
            case "prof": case "proficiency": case "proficiencies":

            break;
            case "subraces": case "subrace":

            break;
            case "speed":

            break;
            case "description":

            break;
        }
        return traitOutput;
    }

    public string GetClassTrait(string trait){
        string traitOutput = "";
        switch (trait.ToLower()){
            case "feat": case "feature":

            break;
            case "prof": case "proficiency": case "proficiencies":

            break;
            case "subclasses": case "subclass":

            break;
            case "maxhp": case "maxhealth":

            break;
            case "hitdie": case "hd": case "die": case "dice":

            break;
            case "attribute1": case "attribute 1":

            break;
            case "attribute2": case "attribute 2":

            break;
        }
        return traitOutput;
    }

    public string GetFeatureTrait(string trait){
        string traitOutput = "";
        return traitOutput;
    }

    public void UpdateRaceDescription(GameObject textObj){
        Text textRef = textObj.GetComponent<Text>();
        List<string> raceNames = baseRaces.GetListOfProperty("names");
        List<string> raceDescs = baseRaces.GetListOfProperty("descriptions");
        if(textRef != null){
            int i = 0;
            while(i<raceNames.Count){
                if (RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text ==raceNames[i]){
                    textRef.text = raceDescs[i];
                }
                i++;
            }
        }
        else
        {
            TMPro.TextMeshProUGUI TMPRef = textObj.GetComponent<TMPro.TextMeshProUGUI>();
            int i =0;
            while(i<raceNames.Count){
                if (RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text ==raceNames[i]){
                    textRef.text = raceDescs[i];
                }
                i++;
            }

        }
    }

    public void PopulateSubrace(){
        string raceName = RaceDropdown.transform.GetChild(0).gameObject.GetComponent<Text>().text;
        List<string> subraceOptions = new List<string>();
        subraceOptions.Add("Choose Subrace");
        foreach (var race in baseRaces.raceList)
        {
            if( race.primaryRace == raceName){
                List<string> temp = new List<string>(race.subraces.Split(','));
                foreach (var item in temp)
                {
                    subraceOptions.Add(item);
                }
                break;
            }
        }
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        SubraceDropdown.GetComponent<Dropdown>().AddOptions(subraceOptions);
    }

    public void UpdateClassDescription(GameObject textObj){
        
    }
}
