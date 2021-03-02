using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKILLLIST : MonoBehaviour
{
    [SerializeField]
    private GameObject skillTemplate;
    private static string[,] skillNamesList;
    // Start is called before the first frame update
    void Start()
    {
        skillNamesList = new string[,]{
            {"Acrobatics","DEX"},{"Animal Handling","WIS"},{"Arcana", "INT"}, 
            {"Athletics","STR"},{"Deception","CHA"},{"History", "INT"},
            {"Insight","WIS"},{"Intimidation","CHA"},{"Investigation","INT"}, 
            {"Medicine","WIS"},{"Nature","INT"},{"Perception","WIS"},
            {"Performance","CHA"},{"Persuasion","CHA"},{"Religion","INT"},
            {"Sleight of Hand","DEX"},{"Stealth","DEX"},{"Survival","WIS"}};
        for(int i =0; i<skillNamesList.GetLength(0); i++){
            GameObject skill = Instantiate(skillTemplate) as GameObject;
            skill.SetActive(true);
            //skill.GetComponent<SKILLITEM>.SetName(skillNameList[i][0]);
            //skill.GetComponent<SKILLITEM>.SetAttribute(skillNameList[i][1]);

            skill.transform.SetParent(skillTemplate.transform.parent, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
