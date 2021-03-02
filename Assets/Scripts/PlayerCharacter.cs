using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
public class PlayerCharacter
{
    // Start is called before the first frame update



    public int strength = 0;
    public int dexterity = 0;
     public int constitution = 0;
    public int intelligence = 0;
    public int wisdom = 0;
    public int charisma = 0;
    public int speed = 0;
    public int proficiency = 0;
    public int height = 0;
    public int hitDie = 0;
    public int level = 0;
    public int money = 0;

    public int health = 0;

    public int maxHealth = 0;
    public string characterName = "";
    public string playerName = "";
    public string playerID = "";
    public string background = "";
    public string charRace;
    public List<ClassLevel> classes = new List<ClassLevel>();
    public List<string> features = new List<string>();
    public List<string> proficiencies = new List<string>();
    public List<string> spells = new List<string>();

        public bool HasNulls(){
            return(strength==0||dexterity==0||constitution==0||intelligence==0||wisdom==0||charisma==0||proficiency==0||height==0||hitDie==0||level==0||maxHealth==0||characterName==""||playerName==""||charRace==null||classes==null||background=="");

            
        }
        public string ToJsonString(){
            return JsonUtility.ToJson(this);

        }

    void Awake(){
        if(HasNulls()){
            Debug.Log(this + " has null data.");
        }
    }

    public PlayerCharacter(){}
    
}
