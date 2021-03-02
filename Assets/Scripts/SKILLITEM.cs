using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKILLITEM : MonoBehaviour
{

    [SerializeField]
    private Text skillName;
    private Text skillAttribute;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName(string text){
        skillName.text = text;
    }
    public void SetAttribute(string text){
        skillAttribute.text = text;
    }

    public void OnClick(){

    }
}
