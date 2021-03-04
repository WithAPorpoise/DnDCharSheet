using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
public class PlayerCharacter
{
    



    public int strength = 0; 
    public int dexterity = 0;
    public int constitution = 0;
    public int intelligence = 0;
    public int wisdom = 0;
    public int charisma = 0;
    public int level = 0;
    public int proficiency = 0; //Procedural

    public float speed = 30; //Procedural
    public float jump = 5;
    public float climb = 10;

    public int height = 0;
    public int weight = 0; 
    public int money = 0; //Procedural
    public int age = 20;

    public int hitDie = 0; //Procedural
    public int health = 0; //Procedural
    public int maxHealth = 0; //Procedural
    public int xp = 0; //Procedural
    public int maxXp = 355000; //Procedural
    public int armorClass = 10;

    public string characterName = "";
    public string playerName = "";
    public string playerID = ""; //Procedural
    public string background = "";
    public string charRace = "";
    public string subrace = "";
    public List<string> classes = new List<string>();
    public List<string> subclasses = new List<string>();
    public List<string> features = new List<string>(); //Procedural
    public List<string> proficiencies = new List<string>(); //Procedural
    public List<string> spells = new List<string>();
    public List<string> items = new List<string>();

        public bool HasNulls(){
            return(strength==0||dexterity==0||constitution==0||intelligence==0||wisdom==0||charisma==0||proficiency==0||height==0||hitDie==0||maxHealth==0||characterName==""||playerName==""||charRace==""||classes==null||background=="");

            
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
