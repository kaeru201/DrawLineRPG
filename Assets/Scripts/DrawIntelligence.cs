using UnityEngine;
using System.Collections.Generic;


//線を描くための情報を扱っているスクリプト
//DrawLinePlaseにアタッチしておく
public class DrawIntelligence : MonoBehaviour
{
    [SerializeField] SkillButton skillButton;

    [SerializeField] int[] skillRange = new int[6];
    [SerializeField] string[] skillDescription = new string[6];

    


    public int[] SkillRange { get => skillRange; set => skillRange = value; }
    public string[] SkillDescription { get => skillDescription; set => skillDescription = value; }

    //swich

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
