using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseClassList
{
    // Start is called before the first frame update
    public List<ClassLevel> Artificer = new List<ClassLevel>();
    public List<ClassLevel> Barbarian = new List<ClassLevel>();
    public List<ClassLevel> Bard = new List<ClassLevel>();
    public List<ClassLevel> Cleric = new List<ClassLevel>();
    public List<ClassLevel> Druid = new List<ClassLevel>();
    public List<ClassLevel> Fighter = new List<ClassLevel>();
    public List<ClassLevel> Monk = new List<ClassLevel>();
    public List<ClassLevel> Paladin = new List<ClassLevel>();
    public List<ClassLevel> Ranger = new List<ClassLevel>();
    public List<ClassLevel> Warlock = new List<ClassLevel>();
    public List<ClassLevel> Wizard = new List<ClassLevel>();

    public List<string> GetListOfProperty(string property){
        List<string> propertyList = new List<string>();
        switch(property){
            case "name":case "names":case "classes":case "class":
                propertyList.Add(Artificer[0].className);
                propertyList.Add(Barbarian[0].className);
                propertyList.Add(Bard[0].className);
                propertyList.Add(Cleric[0].className);
                propertyList.Add(Druid[0].className);
                propertyList.Add(Fighter[0].className);
                propertyList.Add(Monk[0].className);
                propertyList.Add(Ranger[0].className);
                propertyList.Add(Warlock[0].className);
                propertyList.Add(Wizard[0].className);
            break;
            default:
                Debug.LogError("This property implementation is not available yet.");
            break;
        }
        return propertyList;
    }
}
