using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseRaceList
{
    public List<RaceTraits> raceList = new List<RaceTraits>();

    public List<string> GetListOfProperty(string property){
        List<string> propertyList = new List<string>();
        
        switch(property.ToLower()){
            case "name":case "names":case "races":case "race":
                foreach (var race in raceList)
                {
                    propertyList.Add(race.primaryRace);
                }
            break;
            default:
                    Debug.LogError("This property implementation is not available yet.");
            break;
        }

        RaceTraits currentRace;
        currentRace = raceList.Find(item => item.primaryRace == property);
        if(currentRace != null){
            propertyList = new List<string>(currentRace.subraces.Split(','));
        }
        
        return propertyList;
    }

}
