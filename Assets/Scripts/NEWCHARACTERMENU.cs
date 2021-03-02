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
    public BaseClassList baseClasses = new BaseClassList();
    public List<TextAsset> jsonFiles;

    // Start is called before the first frame update
    void Start()
    {
        RaceClassPanel = GameObject.Find("RaceClassPanel");
        RaceDropdown = RaceClassPanel.transform.Find("RaceDropdown").gameObject;
        RaceDropdown.GetComponent<Dropdown>().ClearOptions();
        SubraceDropdown = RaceClassPanel.transform.Find("SubraceDropdown").gameObject;
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        ClassDropdown = RaceClassPanel.transform.Find("ClassDropdown").gameObject;
        ClassDropdown.GetComponent<Dropdown>().ClearOptions();
        SubclassDropdown = RaceClassPanel.transform.Find("SubclassDropdown").gameObject;
        SubclassDropdown.GetComponent<Dropdown>().ClearOptions();

        if(jsonFiles.Count == 0){
            jsonFiles = new List<TextAsset>(Resources.LoadAll<TextAsset>("Data"));
        }
        baseClasses = JsonUtility.FromJson<BaseClassList>(jsonFiles[0].text);
        
        if(SubraceDropdown = null){
        SubraceDropdown = GameObject.Find("SubraceDropdown");
        SubraceDropdown.GetComponent<Dropdown>().ClearOptions();
        }
        if(SubclassDropdown = null){
            
        SubclassDropdown = GameObject.Find("SubclassDropdown");
        SubclassDropdown.GetComponent<Dropdown>().ClearOptions();
        }
    }

    // Update is called once per frame
    void Update()
    {   
/*        if(SubraceDropdown.GetComponent<Dropdown>().isActiveAndEnabled == true && SubraceDropdown.GetComponent<Dropdown>().options.Count <2){
            PopulateDropdown(SubraceDropdown.GetComponent<Dropdown>(), Resources.LoadAll<CharRace>("Subraces"+RaceDropdown.GetComponent<Dropdown>().value));
        }
        if(SubclassDropdown.GetComponent<Dropdown>().isActiveAndEnabled == true && SubclassDropdown.GetComponent<Dropdown>().options.Count <2){
            PopulateDropdown(SubclassDropdown.GetComponent<Dropdown>(), Resources.LoadAll<CharRace>("Subraces"+ClassDropdown.GetComponent<Dropdown>().value));
        }
*/    }

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

    public void OnSaveButtonClicked(InputField NameInput){
        GameManager.SaveNewCharacter(NameInput);
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

}
