using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "CharClass", menuName = "Assets/CharClass", order = 0)]
public class CharClass : ScriptableObject
{
    [SerializeField]
    protected string className;
    [SerializeField]
    protected int[] bonuseAtLevel;
    [SerializeField]
    protected int hitDie;
    [SerializeField]
    protected string[] saves;
    [SerializeField]
    protected string[] skills;
    [SerializeField]
    protected string[] proficiencies;
    [SerializeField]
    protected StrRow[] featsAtLevel;
    [SerializeField]
    protected string[] spellsAtLevel;
    [SerializeField]
    protected string[] specialAtLevel;
    [SerializeField]
    protected string[] subClasses;

}
