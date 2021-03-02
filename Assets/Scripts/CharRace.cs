using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

[CreateAssetMenu(fileName = "CharRace", menuName = "Assets/CharRace", order = 0)]
public class CharRace : ScriptableObject 
{
    [SerializeField]
    protected string raceName;
    [SerializeField]
    protected string[] abilityScores;
    [SerializeField]
    //ages at which the race on average goes from 
    //infant->child->young adult->adult->elder->death
    protected int[] ages; 
    [SerializeField]
    protected int[] heights;
    [SerializeField]
    protected int[] weights;
    [SerializeField]
    protected string[] languages;
    [SerializeField]
    protected string[] feats;

}
